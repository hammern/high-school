import json
import urllib.request

data = urllib.request.urlopen("http://localhost:5000/view/Europe").read()
output = json.loads(data)
print(output)
