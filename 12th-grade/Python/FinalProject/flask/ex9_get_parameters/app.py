from flask import Flask, make_response, render_template, request
import uuid

app = Flask(__name__)


@app.route('/')
def home():
    get_parameters = request.args

    return render_template('home.html', args=get_parameters)


if __name__ == '__main__':
    app.run()