Inigo = "Hello, my name is Inigo Montoya"
print(Inigo[:len(Inigo)-26])
print(Inigo[7:14])
print(Inigo[::2])
print(Inigo[2:20:2])

print("c:cyber\\number1\\b52")

sentenceInput = input("Please enter a sentence\n> ")
sentenceOutput = ""
for x in range(0, len(sentenceInput)):
    if sentenceInput[x:x+1] == 'a':
        sentenceOutput = sentenceOutput + 'aba'
    elif sentenceInput[x:x+1] == 'e':
        sentenceOutput = sentenceOutput + 'ebe'
    elif sentenceInput[x:x+1] == 'i':
        sentenceOutput = sentenceOutput + 'ibi'
    elif sentenceInput[x:x+1] == 'o':
        sentenceOutput = sentenceOutput + 'obo'
    elif sentenceInput[x:x+1] == 'u':
        sentenceOutput = sentenceOutput + 'ubu'
    elif sentenceInput[x:x+1] == ' ':
        sentenceOutput = sentenceOutput + ' '
    else:
        sentenceOutput = sentenceOutput + sentenceInput[x:x+1]
print(sentenceOutput)
