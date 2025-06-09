def length_of_sentence(sentence):
    """
    This function prints the input and it's length.
    """
    print("The sentence is \"{}\" and it's {} characters long.".format(sentence, len(sentence)))


def high_low(low, high, num):
    """
    This function receives 3 numbers:
    High - integer, the biggest number.
    Low - integer, the smallest number.
    Num - integer.
    Returns "True" if the number is between the range of low-high. Otherwise, it returns "False".
    """
    if low < num < high:
        return True
    else:
        return False


def exercise1():
    """
    This function takes user input and prints the input and it's length.
    """
    sentence = input("Please enter a sentence:\n> ")
    length_of_sentence(sentence)


def exercise2():
    """
    This function receives numbers from the user until the number "0" is entered.
    The function prints, for each number, if it a 2-digit number or not.
    """
    num = 1
    while num != 0:
        num = int(input("Please enter a number. When you finish enter \"0\":\n> "))
        if high_low(9, 100, num):
            print("The number is a 2-digit number.")
        else:
            print("The number isn't a 2-digit number.")


def main():
    exercise1()
    print()
    exercise2()


main()
