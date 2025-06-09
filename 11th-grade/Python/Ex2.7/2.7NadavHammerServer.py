__author__ = "Nadav Hammer"
""" A client-server program that allows various functions """

import socket
import glob
import os
import shutil
import subprocess
from PIL import ImageGrab
from NadavHammerProtocol import *


HELP_STR = """
Printscreen: Saves an image of the screen
Clipboard: Copy/Paste
Prog: Opens a program from a given path
CopyFile: Copies a file from a given path and pastes it at a different given path
ShowFolder: Shows all of the files inside a given folder
Delete: Deletes a file in a given path
Exit: close connection
"""

CLIPBOARD = ""


def create_server():
    """ creates a server and listens for a client """
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind(("0.0.0.0", SERVER_PORT))
    server_socket.listen(1)
    return server_socket


def print_screen(client_socket):
    """ Saves an image of the screen """
    im = ImageGrab.grab()
    protocol_send(client_socket, "Please give a full path to the file you want to save (including file name)\n"
                                 "For example: C:\Cyber\\1.txt\n"
                                 "This will save the file on the server computer")
    printscreen_path = protocol_recv(client_socket)
    try:
        im.save(printscreen_path)
        send_file(client_socket, printscreen_path)
    except Exception as e:
        error_message = "path given is incorrect: {}".format(e)
        print(error_message)
        protocol_send(client_socket, error_message)


def send_file(client_socket, file_path):
    """ Sends a file to the client """
    file_size = str(os.path.getsize(file_path))
    protocol_send(client_socket, "save_file,{}".format(file_size))
    with open(file_path, "rb") as f:
        while True:
            buf = f.read(FILE_BUFFER)
            if len(buf) == 0:
                break
            client_socket.send(buf)
    print("File sent,", file_size, "bytes")


def clipboard(client_socket):
    """ Allows the client to copy/paste text """
    global CLIPBOARD
    protocol_send(client_socket, "Copy/Paste")
    ans = protocol_recv(client_socket)
    if ans == "Copy":
        protocol_send(client_socket, "Type what you would like to be copied")
        CLIPBOARD = protocol_recv(client_socket)
        protocol_send(client_socket, "copied")
    elif ans == "Paste":
        protocol_send(client_socket, CLIPBOARD)
    else:
        protocol_send(client_socket, "Illegal Request")


def open_program(client_socket):
    """ Opens a program from a given path """
    protocol_send(client_socket, "What program would you like to open?\nPlease note that sometimes full path is needed")
    prog_name = protocol_recv(client_socket)
    try:
        subprocess.call(prog_name)
        protocol_send(client_socket, "executed")
    except Exception as e:
        error_message = "program given is incorrect: {}".format(e)
        print(error_message)
        protocol_send(client_socket, error_message)


def copy_file(client_socket):
    """ Copies a file from a given path and pastes it at a different given path """
    protocol_send(client_socket, "Please give a full path to the file you want to copy (including file name)\n"
                                 "For example: C:\Cyber\\1.txt")
    copy_path = protocol_recv(client_socket)
    protocol_send(client_socket, "Please give a full path to the new file location (including file name)\n"
                                 "For example: C:\Cyber\\2.txt")
    copy_to_path = protocol_recv(client_socket)
    try:
        shutil.copy(copy_path, copy_to_path)
        protocol_send(client_socket, "file copied")
    except Exception as e:
        error_message = "Path given is incorrect: {}".format(e)
        print(error_message)
        protocol_send(client_socket, error_message)


def show_files_in_folder(client_socket):
    """ Shows all of the files inside a given folder """
    protocol_send(client_socket, "Please give full path to folder")
    files_location = protocol_recv(client_socket)
    try:
        files_list = "\n".join(glob.glob(files_location + "\\*.*"))
        protocol_send(client_socket, files_list)
    except Exception as e:
        error_message = "Path given is incorrect: {}".format(e)
        print(error_message)
        protocol_send(client_socket, error_message)


def delete_file(client_socket):
    """ Deletes a file in a given path """
    protocol_send(client_socket, "Please give full path to delete (including file name)\n"
                                 "For example: C:\Cyber\\1.txt")
    path = protocol_recv(client_socket)
    try:
        os.remove(path)
        protocol_send(client_socket, "deleted")
    except Exception as e:
        error_message = "Path given is incorrect: {}".format(e)
        print(error_message)
        protocol_send(client_socket, error_message)


def server_loop(server_socket):
    """ the main server loop. sends back the information sent from the client """
    client_socket, address = server_socket.accept()
    protocol_send(client_socket, "Server Ready")

    while True:
        message = protocol_recv(client_socket)
        print("Received message from client")
        if message == "Exit":
            print("Closing server")
            break
        elif message == "Help":
            protocol_send(client_socket, HELP_STR)
        elif message == "Printscreen":
            print_screen(client_socket)
        elif message == "Clipboard":
            clipboard(client_socket)
        elif message == "Prog":
            open_program(client_socket)
        elif message == "CopyFile":
            copy_file(client_socket)
        elif message == "ShowFolder":
            show_files_in_folder(client_socket)
        elif message == "Delete":
            delete_file(client_socket)
        elif message == "Error":
            print("Connection Error")
            break
        else:
            print("Illegal Request sent by the client")
            protocol_send(client_socket, "Illegal Request")
        print("Action finished")

    client_socket.close()
    server_socket.close()


def main():
    server_socket = create_server()
    server_loop(server_socket)


if __name__ == '__main__':
    main()
