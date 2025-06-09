def bottles_of_beer(num_bottles):
    """
    This function uses num_bottles (integer).
    It will print the words for the song "99 bottles of beer".
    """
    while num_bottles > 0:
        print("{} bottles of beer on the wall, {} bottles of beer.".format(num_bottles, num_bottles))
        print("Take one down, pass it around, {} bottles of beer on the wall.".format(num_bottles - 1))
        num_bottles -= 1


def my_abs(num):
    """
    This function returns the absolute value of num.
    """
    if num >= 0:
        return num
    else:
        return num * (-1)


def my_pow(num1, num2):
    """
     This function returns num1^num2
    """
    return num1**num2


def my_max(num1, num2):
    """
    This function returns the biggest number out of num1 and num2.
    """
    if num1 > num2:
        return num1
    else:
        return num2


def main():
    print("How many bottles are on the wall?")
    num_bottles = int(input("> "))
    bottles_of_beer(num_bottles)
    print("Please enter number 1:")
    value1 = int(input("> "))
    print("Please enter number 2:")
    value2 = int(input("> "))
    max = my_max(value1, value2)
    absolute = my_abs(max)
    print("The bigger number is {}.".format(absolute))
    print("2^{} = {}".format(absolute, my_pow(2, absolute)))


main()
