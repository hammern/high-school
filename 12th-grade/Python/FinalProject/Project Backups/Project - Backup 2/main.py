__author__ = "Nadav Hammer"
"""  """

from flask import Flask, render_template, url_for, redirect, request, make_response, session
from flask_socketio import SocketIO, send, emit, join_room, leave_room, close_room, rooms
from flask_login import LoginManager, login_required, login_user, logout_user, current_user, UserMixin
import uuid
import sqlite3
import hashlib
import os

app = Flask(__name__)
app.config['SECRET_KEY'] = "#\x07$\xad\xcd\xa5l<]\xb1'\x12\xf8\x87SM"
app.config['SESSION_REFRESH_EACH_REQUEST'] = False
# app.config.update(SESSION_REFRESH_EACH_REQUEST=True)
socketio = SocketIO(app)  # logger=True
login_manager = LoginManager()
login_manager.login_view = 'login'  # Tell Flask the URL of the landing that we are dealing with
login_manager.init_app(app)

SERVER_STATE = ''

URANDOM_SIZE = 10
HASH_ITERATIONS = 100000

DB_NAME = "DB.db"
MESSAGE_SEPARATOR = ';$;'

USER_ID = ""


class User(UserMixin):
    id = None

    def __init__(self, user_id):
        self.id = user_id


@app.before_request
def make_session_permanent():
    session.permanent = True
    # session["_user_id"] = USER_ID


# @app.before_request
# def make_session_permanent():
#     print(session.get("_user_id"))
#     global USER_ID
#     USER_ID = session.get("_user_id")
#     session.permanent = True
#
#
# @app.after_request
# def temp(a):
#     session["_user_id"] = USER_ID
#     print(session["_user_id"])
#     session.permanent = True


@login_manager.user_loader
def my_load_user(user_id):
    # TODO
    # After setting a global variable (USER_ID) as a username and then changing session["_user_id"] to USER_ID
    # before every request this function was finally called
    print("load_user", user_id)
    return User.get_id()


# def get_session_id():
#     if request.cookies.get('sessionID') is None:
#         session = str(uuid.uuid4())
#     else:
#         return request.sid


@app.route('/')
def index():
    """ opens index.html file on start of connection """
    resp = make_response(render_template('index.html'))
    # if request.cookies.get('sessionID') is None:
    #    resp.set_cookie('sessionID', str(uuid.uuid4()))
    return resp


@app.route('/rooms/<room_number>')
def get_rooms(room_number):
    print("RoomID:", room_number)
    return render_template('rooms.html')


@app.route('/login')
def login():
    print("login:", current_user.is_authenticated)
    print(login_manager._user_callback)
    print(session.get("_user_id"))
    if current_user.is_authenticated:
        print(current_user)
        return redirect('/')
    return render_template('login.html')


@app.route('/register')
def register():
    return render_template('register.html')


@socketio.on('connect')
def connect():
    """ action performed at connection from the client """
    emit('listen', {'data': 'Connected'})


# @socketio.on('disconnect')
# def disconnect():
#     print('Client disconnected')


@socketio.on('Create Room')
def create_room():
    # while (room_id := (str(uuid.uuid4())).split('-')[0]) in ROOMS.keys():
    #     continue
    # ROOMS[room_id] = request.sid

    room_id = (str(uuid.uuid4())).split('-')[0]
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        room_id_exists = True
        while room_id_exists:
            cur.execute("SELECT room_id FROM rooms WHERE room_id=?", (room_id,))
            result = cur.fetchone()
            if result:  # room id exists in database
                room_id = (str(uuid.uuid4())).split('-')[0]
            else:
                room_id_exists = False
                cur.execute("INSERT INTO rooms VALUES (?, ?, ?, ? ,?, ?)",
                            (room_id, request.sid, 0, "", "AWEm4tA2hMc", "AWEm4tA2hMc,"))
                db.commit()

    emit('Join Room', room_id)


@socketio.on('join')
def on_join(data):
    username = data['username']
    room = data['roomId']
    print("Join room:", data['roomId'])
    join_room(room)
    print("Included rooms:", rooms(request.sid))
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()

        cur.execute("SELECT room_id FROM rooms WHERE room_id=?", (data['roomId'],))
        result = cur.fetchone()
        if not result:  # room doesn't exist in database
            cur.execute("INSERT INTO rooms VALUES (?, ?, ?, ? ,?, ?)",
                        (data['roomId'], request.sid, 0, "", "AWEm4tA2hMc", "AWEm4tA2hMc,"))

        cur.execute("UPDATE rooms SET num_connected_users = num_connected_users + 1 WHERE room_id=?", (data['roomId'],))

        # send chat history
        cur.execute("SELECT chat FROM rooms WHERE room_id=?", (data['roomId'],))
        chat = cur.fetchone()[0]
        if chat:
            for message in chat.split(MESSAGE_SEPARATOR):
                emit('New Message', message)

        server_message = 'SERVER: ' + username + ' has entered the room.'
        emit('New Message', server_message, room=room)

        # update server message in database
        server_message += MESSAGE_SEPARATOR
        cur.execute("UPDATE rooms SET chat = chat || ? WHERE room_id=?", (server_message, data['roomId'],))

        # send video history
        cur.execute("SELECT video_history FROM rooms WHERE room_id=?", (data['roomId'],))
        video_history = cur.fetchone()[0]
        if video_history:
            for video in video_history.split(','):
                if video != "":
                    emit('Update Video History', video)

        # Synchronize video and video time
        cur.execute("SELECT video_id FROM rooms WHERE room_id=?", (data['roomId'],))
        video_id = cur.fetchone()[0]

        emit('get current time', {'user': request.sid, 'videoId': video_id, 'roomId': data['roomId']},
             room=data['roomId'], include_self=False)

        db.commit()


@socketio.on('update player')
def update_player(data):
    print(data)

    # TODO: (optional) measure delay of request and compensate smartly
    data['currentTime'] += 0.375  # compensate for delay of loading the video

    emit('Change Video', data, room=data['user'])
    emit('change playback rate', data['playbackRate'], room=data['user'])


@socketio.on('leave')
def on_leave(data):
    username = data['username']
    room = data['roomId']
    leave_room(room)
    print("Leave room", room)
    print("Included rooms:", rooms(request.sid))

    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()

        cur.execute("UPDATE rooms SET num_connected_users = num_connected_users - 1 WHERE room_id=?", (data['roomId'],))

        cur.execute("SELECT num_connected_users FROM rooms WHERE room_id=?", (data['roomId'],))
        num_connected_users = cur.fetchone()[0]

        if num_connected_users < 1:
            close_room(room)
            cur.execute("DELETE FROM rooms WHERE room_Id=?", (data['roomId'],))
        else:
            server_message = 'SERVER: ' + username + ' has left the room.'
            emit('New Message', server_message, room=room)

            # update server message in database
            server_message += MESSAGE_SEPARATOR
            cur.execute("UPDATE rooms SET chat = chat || ? WHERE room_id=?", (server_message, data['roomId'],))

        db.commit()


@socketio.on('Change Player State')
def change_player_state(data):
    global SERVER_STATE
    if data['state'] != SERVER_STATE:
        if data['currentTime'] > float(-1):
            if data['state'] == 'Buffering':
                emit('Play', data['currentTime'], room=data['roomId'], include_self=False)
                SERVER_STATE = 'Play'
            else:
                emit(data['state'], data['currentTime'], room=data['roomId'], include_self=False)
                SERVER_STATE = data['state']


@socketio.on('Change Playback Rate')
def change_playback_speed(data):
    emit('change playback rate', data['playback rate'], room=data['roomId'], include_self=False)


@socketio.on('Send Link')
def send_link(data):
    """ sends the new link to the client """
    video_id = data['videoId'].split("=")[-1]

    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("UPDATE rooms SET video_id = ? WHERE room_id=?", (video_id, data['roomId'],))
        cur.execute("UPDATE rooms SET video_history = video_history || ? WHERE room_id=?",
                    (video_id + ',', data['roomId'],))
        db.commit()
    emit('Change Video', {'videoId': video_id, 'currentTime': 0, 'lastPlayerState': 2}, room=data['roomId'])
    emit('Update Video History', video_id, room=data['roomId'])


@socketio.on('Send Message')
def send_message(data):
    """  """
    print("Sending message to roomID:", data.get('roomId'))
    print("Included rooms:", rooms(request.sid))

    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()

        new_message = data['username'] + ": " + data['message']
        emit('New Message', new_message, room=data['roomId'])

        new_message += MESSAGE_SEPARATOR
        cur.execute("UPDATE rooms SET chat = chat || ? WHERE room_id=?", (new_message, data['roomId'],))

        db.commit()


@socketio.on('Register')
def register_user(data):
    """  """
    print(data)
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("SELECT username FROM users WHERE username=?", (data['username'],))
        result = cur.fetchone()
        if result:  # username exists in database
            print("Username already exists")
            emit('register error')
        else:
            salt = os.urandom(URANDOM_SIZE)
            cur.execute("INSERT INTO Users VALUES (?, ?, ?)",
                        (data['username'], salt, encrypt_password(data['password'].encode(), salt)))
            db.commit()
            emit('register successful')


@socketio.on('Login')
def auth_login(data):
    global USER_ID
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("SELECT * FROM users WHERE username=?", (data['username'],))
        user_info = cur.fetchone()
        print(user_info)
        if user_info:  # username exists in database
            salt = user_info[1]
            if encrypt_password(data['password'].encode(), salt) == user_info[2]:
                print("Logged in successfully")
                USER_ID = user_info[0]
                login_user(User(user_info[0]))  # remember=True if box is checked
                # return render_template('index.html')
                print(session["_user_id"])
                emit('login successful')
            else:
                print("Wrong password!")
                emit('login error', 'password_error')
        else:
            print("Username doesn't exist")
            emit('login error', 'username_error')


def encrypt_password(password, salt):
    return hashlib.pbkdf2_hmac('sha256', password, salt, HASH_ITERATIONS)


@app.route('/logout')
@login_required
def logout():
    logout_user()
    return render_template('index.html')


# reading cookies: sessionID = request.cookies.get('sessionID')
# line above might be useful for username for join and leave room

# add permanent link to room to registered users
# save room ids to database with user and room id
# when different user sets a permanent link check in database if room id exists
# permanent links could save the last played video


# TODO: FEATURES TO ADD
# video history
# user list
# private and public rooms
# user permissions
# admin account with access to list of all rooms

if __name__ == '__main__':
    socketio.run(app, host='0.0.0.0', port=5000, debug=True)
