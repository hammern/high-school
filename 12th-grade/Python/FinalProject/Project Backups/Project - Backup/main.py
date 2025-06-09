__author__ = "Nadav Hammer"
"""  """

from flask import Flask, render_template, url_for, redirect, request, make_response
from flask_socketio import SocketIO, send, emit, join_room, leave_room, close_room, rooms
import uuid
import sqlite3

app = Flask(__name__)
app.config['SECRET_KEY'] = "secret!"
socketio = SocketIO(app)  # logger=True

ROOMS = {}  # RoomID : Admin (creator of room)


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
    # print("RoomID:", room_number)
    # TODO: (maybe) if room_number not in ROOMS.keys(): 404 error / room number doesn't exist
    # allows to add permanent links to registered users
    return render_template('rooms.html')


@app.route('/login')
def login():
    return render_template('login.html')


@app.route('/register')
def register():
    return render_template('register.html')


@socketio.on('Create Room')
def create_room():
    while (room_id := (str(uuid.uuid4())).split('-')[0]) in ROOMS.keys():
        continue
    ROOMS[room_id] = request.sid
    emit('Join Room', room_id)


@socketio.on('join')
def on_join(data):
    username = request.sid
    room = data
    print("Join room:", data)
    join_room(room)
    print("Included rooms:", rooms(request.sid))
    emit('New Message', 'SERVER: ' + username + ' has entered the room.', room=room)


@socketio.on('leave')
def on_leave(data):
    username = request.sid
    room = data
    leave_room(room)
    print("Join room", room)
    emit('New Message', 'SERVER: ' + username + ' has left the room.', room=room)


@socketio.on('connect')
def connect():
    """ action performed at connection from the client """
    emit('listen', {'data': 'Connected'})


@socketio.on('Send Link')
def link(data):
    """ sends the new link to the client """
    video_id = data['videoId'].split("=")[-1]
    emit('Change Video', video_id, room=data['roomId'])


# @socketio.on('Update Time')  # change time when user selects different time
# def time(data):
#     """ sends the new time to the client """
#     emit('Change Time', int(data), broadcast=True, include_self=False)


@socketio.on('Play Player')
def play(data):
    """  """
    if data['currentTime'] > float(-1):
        emit('Play', data['currentTime'], room=data['roomId'], include_self=False)


@socketio.on('Pause Player')
def pause(data):
    """  """
    if data['currentTime'] > float(-1):
        emit('Pause', data['currentTime'], room=data['roomId'], include_self=False)


@socketio.on('Send Message')
def pause(data):
    """  """
    print("Sending message to roomID:", data.get('roomId'))
    print("Included rooms:", rooms(request.sid))
    emit('New Message', data['message'], room=data['roomId'])

# TODO: Fix margin of login and register
# TODO: Add sqlite to username and password
# TODO: Add encryption to passwords
# TODO: Add sqlite to rooms (when room has zero users delete the room) (maybe not needed)
# reading cookies: sessionID = request.cookies.get('sessionID')
# line above might be useful for username for join and leave room

# add permanent link to room to registered users
# save room ids to database with user and room id
# when different user sets a permanent link check in database if room id exists


if __name__ == '__main__':
    socketio.run(app, host='0.0.0.0', port=5000, debug=True)
