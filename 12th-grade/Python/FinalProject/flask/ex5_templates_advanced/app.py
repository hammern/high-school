from flask import Flask, render_template

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


if __name__ == '__main__':
    app.run()