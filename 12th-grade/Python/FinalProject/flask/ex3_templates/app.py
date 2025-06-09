from flask import Flask, render_template

app = Flask(__name__)


@app.route('/')
def hello():
    return 'Hello, World!'


@app.route('/view/<location>')
def home(location):
    return render_template('view.html', title='Show Flags', location=location)


if __name__ == '__main__':
    app.run()
