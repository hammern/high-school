from flask import Flask

app = Flask(__name__)


@app.route('/')
def hello():
    return 'Hello, World!'


@app.route('/view/<location>')
def home(location):
    return '''
    <html>
        <head>
            <title>View Page</title>
        </head>
        <body>
            <h1>%s</h1>
        </body>
    </html>''' % location


if __name__ == '__main__':
    app.run()
