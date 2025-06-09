Num = input("Please insert a 5 digit number:\n> ")
if len(Num) != 5:
    print("Try again, this time read the instructions.")
else:
    print("You entered the number:", Num)
    Slice1 = Num[0]
    Slice2 = Num[1]
    Slice3 = Num[2]
    Slice4 = Num[3]
    Slice5 = Num[4]
    print("The digits of the number are: {}, {}, {}, {}, {}".format(Slice1, Slice2, Slice3, Slice4, Slice5))
    Sum = int(Slice1) + int(Slice2) + int(Slice3) + int(Slice4) + int(Slice5)
    print("The sum of the digits is:", Sum)
