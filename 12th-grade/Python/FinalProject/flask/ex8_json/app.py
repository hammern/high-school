from flask import Flask,jsonify

app = Flask(__name__)


data = {
    'Asia': [
        {'name': 'Israel', 'flag': 'iw'},
        {'name': 'China', 'flag': 'cn'},
        {'name': 'Japan', 'flag': 'ja'}
    ],
    'Europe': [
        {'name': 'Czech Republic', 'flag': 'cs'},
        {'name': 'Greece', 'flag': 'el'},
        {'name': 'Spain', 'flag': 'es'},
        {'name': 'UK', 'flag': 'en'},
        {'name': 'Italy', 'flag': 'it'}
    ],
    "North America": [
        {'name': 'United States', 'flag': 'enUS'},
        {'name': 'Mexico', 'flag': 'es419'},
        {'name': 'Canada', 'flag': 'enCA'}
    ]
}


@app.route('/')
def home():
    return 'Hello, World!'


@app.route('/view/<location>')
def view(location):
    return jsonify(data[location])


if __name__ == '__main__':
    app.run()