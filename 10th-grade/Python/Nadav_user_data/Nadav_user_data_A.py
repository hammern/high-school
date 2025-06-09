__author__ = "Nadav Hammer"
""" The program will run in a loop and get a username and password fromm the user.
    It will tell him the username or password are incorrect and if both are correct the program will great the user.
    If the user enters "quit" the program will exit. """


def get_user_data_list():
    """ Returns a list containing a list of all the usernames and all of the passwords """
    users_list = []
    passwords_list = []
    with open("user_data.txt", "r") as file:
        for line in file:
            users_list.append(line.split(",")[0])
            passwords_list.append(line.split(",")[1])
    for i in range(0, len(passwords_list)):
        passwords_list[i] = passwords_list[i].replace("\n", "")
    user_data_list = [users_list, passwords_list]
    return user_data_list


def check_username(username, users_list):
    """ Checks if the username the user entered is in user_data.txt """
    username_found = False
    username_index = 0
    for user in users_list:
        if username == user:
            username_found = True
            break
        else:
            username_found = False
            username_index += 1
    return username_found, username_index


def check_password(index, password, passwords_list):
    return passwords_list[index] == password


def main():
    username = ""
    user_data_list = get_user_data_list()
    users_list = user_data_list[0]
    passwords_list = user_data_list[1]
    print("Hello! enter your username and password. When done enter \"quit\" in order to exit")
    while username != "quit":
        username = input("Please enter your username: ")
        if username == "quit":
            break
        found, index = check_username(username, users_list)
        if not found:
            print("Username incorrect")
        else:
            password = input("Please enter your password: ")
            if check_password(index, password, passwords_list):
                print("Welcome {}!".format(username))
            else:
                print("Password incorrect")


if __name__ == '__main__':
    main()
