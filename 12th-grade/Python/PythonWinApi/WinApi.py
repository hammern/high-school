import win32api

# Message box
i = win32api.MessageBox(None, "This is a test", "Testing", 1)

# Local time
t = win32api.GetLocalTime()
print(t)

# Beep
win32api.Beep(500, 500)

# Delete File
try:
    win32api.DeleteFile("test.txt")
except Exception as e:
    print("Error: {0}".format(e))

# Disk
t = win32api.GetDiskFreeSpace("C:\\")
print("Free disk space in bytes: {0}".format(t[0] * t[1] * t[2]))

# Cursor
win32api.SetCursorPos((500, 900))
print(win32api.GetCursorPos())

# State of keyboard
dic = {97: 261, 98: 293, 99: 329, 100: 349, 101: 392, 102: 440, 103: 493, 104: 523, 105: 587}

while True:
    for key in dic:
        if win32api.GetAsyncKeyState(key):
            win32api.Beep(dic[key], 100)
