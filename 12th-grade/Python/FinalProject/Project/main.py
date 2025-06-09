__author__ = "Nadav Hammer"
"""  """

from flask import Flask, render_template, redirect, request, session
from flask_socketio import SocketIO, emit, join_room, leave_room, close_room
from flask_login import LoginManager, login_required, login_user, logout_user, current_user, UserMixin
import uuid
import sqlite3
import hashlib
import os
import requests

app = Flask(__name__)
app.config['SECRET_KEY'] = "#\x07$\xad\xcd\xa5l<]\xb1'\x12\xf8\x87SM"
socketio = SocketIO(app)
login_manager = LoginManager()
login_manager.login_view = 'login'  # Tell Flask the URL of the landing that we are dealing with
login_manager.init_app(app)

ROOMS_STATE = {}

URANDOM_SIZE = 10
HASH_ITERATIONS = 100000

DB_NAME = "DB.db"
MESSAGE_SEPARATOR = ';$;'

DEFAULT_BACKGROUND = "Dark.jpg"


class User(UserMixin):
    """User class used for flask_login.

    Attributes:
        id:
    """
    id = None

    def __init__(self, user_id):
        self.id = user_id


@login_manager.user_loader
def my_load_user(user_id):
    print("load_user:", user_id)
    return User(user_id)


@app.route('/auth')
def internal_auth():
    session["_user_id"] = request.args.get('username')
    return redirect('/')


@app.route('/')
def index():
    """Opens index.html file on start of connection."""
    return render_template('index.html')


@app.route('/rooms/<room_number>')
def get_rooms(room_number):
    print("RoomID:", room_number)
    background = DEFAULT_BACKGROUND
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("SELECT background FROM users WHERE username=?", (current_user.get_id(),))
        db_background = cur.fetchone()
        print("Background in db:", db_background)
        if db_background:
            print("Change background:", db_background[0])
            background = db_background[0]
    return render_template('rooms.html', background=background)


@app.route('/login')
def login():
    return render_template('login.html')


@app.route('/logout')
@login_required
def logout():
    logout_user()
    return render_template('index.html')


@app.route('/register')
def register():
    return render_template('register.html')


@app.route('/profile')
@login_required
def profile():
    two_fa = False
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("SELECT SequenceID FROM users WHERE username=?", (current_user.get_id(),))
        if cur.fetchone()[0]:  # SequenceID exists in database
            two_fa = True
        cur.execute("SELECT background FROM users WHERE username=?", (current_user.get_id(),))
        background = cur.fetchone()[0]
    return render_template('profile.html', two_fa=two_fa, background=background)


@socketio.on('connect')
def connect():
    """Action performed at connection from the client."""
    emit('listen', {'data': 'Connected'})


# @socketio.on('disconnect')
# def disconnect():
#     print('Client disconnected')


@socketio.on('Create Room')
def create_room():
    """Creates a room entry in the database when a user presses the Create Room button in index.html."""
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
                cur.execute("INSERT INTO rooms VALUES (?, ?, ? ,?, ?, ?)",
                            (room_id, 0, "", "AWEm4tA2hMc", "AWEm4tA2hMc,", ""))
                db.commit()
            ROOMS_STATE[room_id] = ""

    emit('Join Room', room_id)


@socketio.on('join')
def on_join(data):
    """Joins a user into a room.

    :param data: dictionary containing user info and which room id to join to
    :type data: dict
    :return:
    """
    username = data['username']
    room = data['roomId']
    print("Join room:", data['roomId'])
    join_room(room)
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()

        # check if room exists in database
        cur.execute("SELECT room_id FROM rooms WHERE room_id=?", (data['roomId'],))
        result = cur.fetchone()
        if not result:  # room doesn't exist in database
            cur.execute("INSERT INTO rooms VALUES (?, ?, ? ,?, ?, ?)",
                        (data['roomId'], 0, "", "AWEm4tA2hMc", "AWEm4tA2hMc,", ""))
            ROOMS_STATE[data['roomId']] = ""

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

        # update current users in database
        current_username = username + ","
        cur.execute("UPDATE rooms SET current_users = current_users || ? WHERE room_id=?",
                    (current_username, data['roomId'],))

        # send current users
        cur.execute("SELECT current_users FROM rooms WHERE room_id=?", (data['roomId'],))
        current_users = cur.fetchone()[0]
        if current_users:
            print(current_users.split(',')[:-2])
            for user in current_users.split(',')[:-2]:
                if user != "":
                    emit('Update Current Users', user)

        # update current users for others in room
        emit("Update Current Users", username, room=data['roomId'])

        # Synchronize video and video time
        cur.execute("SELECT video_id FROM rooms WHERE room_id=?", (data['roomId'],))
        video_id = cur.fetchone()[0]

        emit('get current time', {'user': request.sid, 'videoId': video_id, 'roomId': data['roomId']},
             room=data['roomId'], include_self=False)

        db.commit()


@socketio.on('update player')
def update_player(data):
    """Updates the video player of the user who joined the room to have the same video playing at the same time.

    :param data: dictionary containing all of the information needed to update the player
    :type data: dict
    :return:
    """
    print(data)

    data['currentTime'] += 0.375  # compensate for the delay of loading the video

    emit('Change Video', data, room=data['user'])
    emit('change playback rate', data['playbackRate'], room=data['user'])


@socketio.on('leave')
def on_leave(data):
    """Throws the user from the room and closes the room if there are no more users in the room.

    :param data: dictionary containing the leaving users info
    :type data: dict
    :return:
    """
    username = data['username']
    room = data['roomId']
    leave_room(room)
    print("Leave room", room)

    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()

        cur.execute("UPDATE rooms SET num_connected_users = num_connected_users - 1 WHERE room_id=?", (data['roomId'],))

        cur.execute("SELECT num_connected_users FROM rooms WHERE room_id=?", (data['roomId'],))
        num_connected_users = cur.fetchone()[0]

        if num_connected_users < 1:
            close_room(room)
            cur.execute("DELETE FROM rooms WHERE room_Id=?", (data['roomId'],))
            del ROOMS_STATE[data['roomId']]
        else:
            server_message = 'SERVER: ' + username + ' has left the room.'
            emit('New Message', server_message, room=room)

            # update server message in database
            server_message += MESSAGE_SEPARATOR
            cur.execute("UPDATE rooms SET chat = chat || ? WHERE room_id=?", (server_message, data['roomId'],))

            # remove leaving user from database
            to_remove_username = username + ","
            cur.execute("SELECT current_users FROM rooms WHERE room_id=?", (data['roomId'],))
            current_users = cur.fetchone()[0]
            new_current_users = current_users.replace(to_remove_username, "")
            cur.execute("UPDATE rooms SET current_users = ? WHERE room_id=?", (new_current_users, data['roomId'],))

            emit("Delete Leaving User", username, room=data['roomId'])

        db.commit()


@socketio.on('Change Player State')
def change_player_state(data):
    """Sends a message to change the state of the player of all users connected to the same room.

    :param data: dictionary containing the state and time of the player
    :type data: dict
    :return:
    """
    if data['state'] != ROOMS_STATE[data['roomId']]:
        if data['currentTime'] > float(-1):
            if data['state'] == 'Buffering':
                emit('Play', data['currentTime'], room=data['roomId'], include_self=False)
                ROOMS_STATE[data['roomId']] = 'Play'
            else:
                emit(data['state'], data['currentTime'], room=data['roomId'], include_self=False)
                ROOMS_STATE[data['roomId']] = data['state']


@socketio.on('Change Playback Rate')
def change_playback_speed(data):
    emit('change playback rate', data['playback rate'], room=data['roomId'], include_self=False)


@socketio.on('Send Link')
def send_link(data):
    """Changes video link to all users in the same room.

    :param data: dictionary containing the link to send and the room id to send the link to
    :type data: dict
    :return:
    """
    video_id = data['videoId'].split("=")[-1]

    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("UPDATE rooms SET video_id = ? WHERE room_id=?", (video_id, data['roomId'],))
        cur.execute("UPDATE rooms SET video_history = video_history || ? WHERE room_id=?",
                    (video_id + ',', data['roomId'],))

        server_message = 'SERVER: ' + data['username'] + ' changed the video.'
        emit('New Message', server_message, room=data['roomId'])
        server_message += MESSAGE_SEPARATOR
        cur.execute("UPDATE rooms SET chat = chat || ? WHERE room_id=?", (server_message, data['roomId'],))

        db.commit()
    emit('Change Video', {'videoId': video_id, 'currentTime': 0, 'lastPlayerState': 2}, room=data['roomId'])
    emit('Update Video History', video_id, room=data['roomId'])


@socketio.on('Send Message')
def send_message(data):
    """Sends a message to all users in the same room.

    :param data: dictionary containing the message to send and the room id to send the message to
    :type data: dict
    :return:
    """
    print("Sending message to roomID:", data.get('roomId'))

    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()

        new_message = data['username'] + ": " + data['message']
        emit('New Message', new_message, room=data['roomId'])

        new_message += MESSAGE_SEPARATOR
        cur.execute("UPDATE rooms SET chat = chat || ? WHERE room_id=?", (new_message, data['roomId'],))

        db.commit()


@socketio.on('Register')
def register_user(data):
    """Registers a new user in the database.

    :param data: dictionary containing user info
    :type data: dict
    :return:
    """
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
            cur.execute("INSERT INTO Users VALUES (?, ?, ?, ?, ?)", (data['username'], salt,
                                                                     encrypt_password(data['password'].encode(), salt),
                                                                     DEFAULT_BACKGROUND, None))
            db.commit()
            login_user(User(data['username']), remember=data['remember'])
            emit('register successful', data['username'])


@socketio.on('Login')
def auth_login(data):
    """Authenticates a user logging in.

    :param data: dictionary containing user info
    :type data: dict
    :return:
    """
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("SELECT * FROM users WHERE username=?", (data['username'],))
        user_info = cur.fetchone()
        print(user_info)
        if user_info:  # username exists in database
            salt = user_info[1]
            if encrypt_password(data['password'].encode(), salt) == user_info[2]:
                print("Logged in successfully")
                login_user(User(user_info[0]), remember=data['remember'])
                print("SequenceID:", user_info[4])
                if user_info[4]:  # SequenceID not null
                    emit("Check 2FA", user_info[4])
                else:
                    emit('Auth Successful', user_info[0])
            else:
                print("Wrong password!")
                emit('login error', 'password_error')
        else:
            print("Username doesn't exist")
            emit('login error', 'username_error')


def encrypt_password(password, salt):
    """Encrypts a password using sha256 hash protocol.

    :param password: password to encrypt
    :type password: str
    :param salt: salt for the hash function
    :type salt: bytes
    :return: encrypted password using sha256 hash
    """
    return hashlib.pbkdf2_hmac('sha256', password, salt, HASH_ITERATIONS)


@socketio.on("Activate Auth")
def initialize_2fa():
    params = {'Issuer': 'Sync', 'Label': 'Sync'}
    response = requests.get('https://hisham.ru/api/initialize.php', params=params)
    fa_result = response.json()
    print(fa_result)
    emit("Show QRCode", {'QRCode': fa_result["QRCode"], 'SequenceID': fa_result["SequenceID"]})


@socketio.on("Send 2FA Code")
def verify_2fa(data):
    params = {'SequenceID': data['SequenceID'], 'Value': data['Code']}
    response = requests.post('https://hisham.ru/api/verify.php', data=params)
    fa_verify_result = response.json()
    print(fa_verify_result)
    if fa_verify_result['Verified']:
        with sqlite3.connect(DB_NAME) as db:
            cur = db.cursor()
            cur.execute("UPDATE users SET SequenceID=? WHERE username=?",
                        (fa_verify_result["SequenceID"], current_user.get_id()))
            db.commit()
            emit("Auth Successful", current_user.get_id())


@socketio.on("Disable Auth")
def disable_2fa():
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("UPDATE users SET SequenceID=? WHERE username=?",
                    (None, current_user.get_id()))
        db.commit()


@socketio.on("Change Background")
def change_background(data):
    with sqlite3.connect(DB_NAME) as db:
        cur = db.cursor()
        cur.execute("UPDATE users SET background=? WHERE username=?",
                    (data, current_user.get_id()))
        db.commit()


if __name__ == '__main__':
    socketio.run(app, host='0.0.0.0', port=5000, debug=True)
