__author__ = "Nadav Hammer"
""" Featuring Exercises 7.2-7.5 """


def get_user_input():
    """ This function gets user input and returns a list containing the inputted words """
    input_list = []
    user_input = input("Please enter words. When done press enter twice.\n> ")
    while user_input != "":
        input_list.append(user_input)
        user_input = input("> ")
    return input_list


def ex1():
    """ This function asks the user to input words until an empty string input
        Afterwards it checks if there are the words: yes, no, black, white """
    print("Exercise 7.2:")
    input_list = get_user_input()
    found = False
    for word in ["yes", "no", "black", "white"]:
        if word in input_list:
            found = True
            break
    if found:
        print("Something is wrong")
    else:
        print("Everything is alright")


def ex2():
    """ This function asks the user to input words until an empty string input
        Afterwards it sorts the input from the shortest words to the longest words """
    print("Exercise 7.3:")
    sorted_list = sorted(get_user_input(), key=len)
    print(", ".join(sorted_list))


def ex3():
    """ This function asks the user to input words until an empty string input
        Afterwards it sorts the input by the abc of the last character of the word """
    print("Exercise 7.4:")
    sorted_list = sorted(get_user_input(), key=lambda x: x[-1])
    print(", ".join(sorted_list))


def split_web_address(web_address):
    """ This function asks the user to input a web address and then prints the sub libraries of the address """
    sub_libraries = web_address.split("/")
    return sub_libraries[1: len(sub_libraries)]


def ex4():
    """ This function prints the sub libraries of a web address """
    print("Exercise 7.5:")
    web_address = input("Please enter a web address:\n> ")
    print(split_web_address(web_address))


def main():
    ex1()
    ex2()
    ex3()
    ex4()


if __name__ == '__main__':
    main()
