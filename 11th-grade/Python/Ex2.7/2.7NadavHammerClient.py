__author__ = "Nadav Hammer"
""" A client-server program that allows various functions """

import socket
from NadavHammerProtocol import *


def create_client():
    """ creates a client and tries to connect to a server """
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    try:
        client_socket.connect((SERVER_IP, SERVER_PORT))
        response = protocol_recv(client_socket)
        print(response)
    except Exception as e:
        print("Error connecting to server: ", e)
        client_socket.close()
        client_socket = None
    return client_socket


def client_save_file(client_socket, file_size):
    """ Saves a file on the client computer """
    print("Please give a full path to the file you want to save (including file name)\n"
          "For example: C:\Cyber\\1.txt\n"
          "This will save the file on the client computer")
    file_path = input("> ")
    try:
        with open(file_path, "wb") as f:
            while file_size > 0:
                buf = client_socket.recv(FILE_BUFFER)
                f.write(buf)
                file_size -= len(buf)
        print("File saved at " + file_path)
    except Exception as e:
        print("Error saving file: {}".format(e))
        # receive rest of file without saving
        while file_size > 0:
            buf = client_socket.recv(FILE_BUFFER)
            file_size -= len(buf)


def client_loop(client_socket):
    """ the main client loop. sends information to the server and receives information from the server """
    print("Type Help for help")
    while True:
        data = input("> ")
        protocol_send(client_socket, data)
        response = protocol_recv(client_socket)
        r = response.split(",")
        if r[0] == "save_file":
            client_save_file(client_socket, int(r[1]))
        else:
            print(response)
        if data == "Exit" or response == "Error":
            break

    client_socket.close()


def main():
    client_socket = create_client()
    if client_socket:
        client_loop(client_socket)


if __name__ == '__main__':
    main()
