from flask import Flask, render_template, request
import json

app = Flask(__name__, static_folder='static')
app.config["TEMPLATES_AUTO_RELOAD"] = True

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
def hello():
    return render_template('index.html', title="Home", countries=data)


@app.route('/view/<location>')
def view(location):
    return render_template('view.html', title='Show Flags', location=location, countries=data)


@app.route('/add', methods=['GET', 'POST'])  # allow both GET and POST requests
def add():
    message = ""
    if request.method == 'POST':  # this block is only entered when the form is submitted
        continent = request.form['continent']
        name = request.form['name']
        flag = request.form['flag']
        if continent not in data:
            data[continent] = []
        data[continent].append({'name': name, 'flag': flag})
        message = "Added " + continent + " " + name + " " + flag

    return render_template('add.html', title="Add", message=message)


if __name__ == '__main__':
    app.run()