def my_func(string1, string2, string3, action):
    """
    This function receives 3 strings in english and an integer.
    If the number is 1, the function returns the 3 strings by their length.
    If the number is 2, the function returns the string by the order of the abc.
    For any other number, the function returns none.
    Capital letters will come before small letters.
    """
    if action == 1:
        if len(string1) >= len(string2) >= len(string3):
            return string1, string2, string3
        elif len(string1) >= len(string3) >= len(string2):
            return string1, string3, string2
        elif len(string2) >= len(string1) >= len(string3):
            return string2, string1, string3
        elif len(string2) >= len(string3) >= len(string1):
            return string2, string3, string1
        elif len(string3) >= len(string1) >= len(string2):
            return string3, string1, string2
        else:
            return string3, string2, string1
    elif action == 2:
        letter1 = string1[0]
        letter2 = string2[0]
        letter3 = string3[0]
        if letter1 < letter2 and letter1 < letter3:
            if letter2 < letter3:
                return string1, string2, string3
            else:
                return string1, string3, string2
        elif letter2 < letter1 and letter2 < letter3:
            if letter1 < letter3:
                return string2, string1, string3
            else:
                return string2, string3, string1
        elif letter3 < letter1 and letter3 < letter2:
            if letter1 < letter2:
                return string3, string1, string2
            else:
                return string3, string2, string1
    else:
        return None


def main():
    string1 = input("Please enter the first sentence: \n> ")
    string2 = input("Please enter the second sentence: \n> ")
    string3 = input("Please enter the third sentence: \n> ")
    action = int(input("Please enter the number 1 or 2:\n> "))
    while action != 1 and action != 2:
        print("The input you entered is wrong. Please enter the number again:")
        action = int(input("> "))
    print("\n".join(my_func(string1, string2, string3, action)))


main()
