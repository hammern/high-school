from flask import Flask, make_response, render_template, request
import uuid

app = Flask(__name__)


@app.route('/')
def home():
    session = ""
    is_new_session = False
    if 'sessionID' in request.cookies:
        session = request.cookies.get('sessionID')
    else:
        session = str(uuid.uuid4())
        is_new_session = True

    resp = make_response(render_template('home.html', session=session, remote_ip=request.remote_addr))

    if is_new_session:
        resp.set_cookie('sessionID', session)

    return resp


if __name__ == '__main__':
    app.run()