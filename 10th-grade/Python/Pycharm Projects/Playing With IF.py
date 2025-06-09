x = True
y = False
if x == True:
    print("X")
if y == False:
    print("Y")

z = 5
print("is Z smaller then 10?")
if z < 10:
    print("Yes")
elif z > 10:
    print("No")

print("Are you a human?")
Answer = input(">")
if Answer == "Yes":
    print("Nothing to see here.")
elif Answer == "No":
    print("Welcome to the robot secret base.")
else:
    print("You are not supposed to say that, you dummy!")