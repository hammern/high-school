__author__ = "Nadav Hammer"
""" The program allows new users to register their information.
    It will run in an endless loop (until the user enters an empty string).
    The program receives from the user a username and password.
    If the username is taken or if the password's length is under 8 the program will ask for new info.
    After the user entered an empty string the program prints all of the information inside the file. """


MINIMUM_PASSWORD_LENGTH = 8


def check_if_username_exists(username):
    """ Checks if the username exists in the file """
    username_found = False
    with open("user_data.txt", "r") as file:
        for line in file:
            if line.split(",")[0] == username:
                username_found = True
                break
            else:
                username_found = False
    return username_found


def verify_password(password):
    """ Checks if the length of the password is more than the set length """
    return len(password) >= MINIMUM_PASSWORD_LENGTH


def write_in_file(username, password):
    """ Adds a new user to the file in the format: username,password """
    with open("user_data.txt", "a") as file:
        temp_user = username + "," + password
        file.write(temp_user + "\n")


def print_file():
    """ Prints the contents of the file """
    print("Contents of the file are:\n--------------------------")
    with open("user_data.txt", "r") as file:
        for line in file:
            print(line[:-1])
    print("--------------------------")


def main():
    username = " "
    while username != "":
        username = input("Please enter your username: ")
        if username == "":
            print_file()
            break
        if check_if_username_exists(username):
            print("Username already exists")
        else:
            password = input("Please enter your password: ")
            if verify_password(password):
                write_in_file(username, password)
            else:
                print("Password must be above 8 characters")


if __name__ == '__main__':
    main()
