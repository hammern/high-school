__author__ = "Nadav Hammer"
"""
Features the answer to two exercises for practicing Pep8 and input validation. 
"""


def number_entered(num):
    """ This function receives number and returns a message with the number received """
    return "You entered the number: " + num


def digits_of_num(num):
    """ This function receives number and returns the digits of it with a coma separating them """
    digits = ""
    for i in range(0, len(num) - 1):
        digits += str(num)[i] + ", "
    digits += str(num)[-1]
    return digits


def sum_of_digits(num):
    """ This function receives number and returns the sum of its digits """
    sum_of_dig = 0
    num = int(num)
    while num > 0:
        sum_of_dig += (num % 10)
        num //= 10
    return sum_of_dig


def is_num(num):
    for i in range(0, len(num)):
        if not ('0' <= num[i] <= '9'):
            return False
    return True


def check_input(num):
    """ This function checks if the input is legal """
    return len(num) == 5 and is_num(num) and (0 <= int(num) <= 99999)


def ex1():
    """ A 5-digit number input and then prints:
    the number itself, the digits of the number and the sum of all the digits """
    print("Please enter a 5 digit number:")
    num = input("> ")
    print(number_entered(num))
    print("The digits of the number are: " + digits_of_num(num))
    print("The sum of the digits is: " + str(sum_of_digits(num)))


def ex2():
    """ Exercise 1 with an input validation check """
    print("Please enter a 5 digit number:")
    num = input("> ")
    while not check_input(num):
        print("Please enter a 5 digit number:")
        num = input("> ")
    print(number_entered(num))
    print("The digits of the number are: " + digits_of_num(num))
    print("The sum of the digits is: " + str(sum_of_digits(num)))


def main():
    print("Exercise 1:")
    ex1()
    print("Exercise 2:")
    ex2()


if __name__ == '__main__':
    main()
