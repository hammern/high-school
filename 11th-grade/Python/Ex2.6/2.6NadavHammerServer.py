__author__ = "Nadav Hammer"
"""  """

import socket
import random
from datetime import datetime
from NadavHammerProtocol import *


HELP_STR = """ 
Exit: close connection
Time: show current time
Name: show server name
Rand: return a random number between 0-1000
"""
IP = '0.0.0.0'
PORT = 25565


def create_server():
    """ creates a server and listens for a client """
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((IP, PORT))
    server_socket.listen(1)
    return server_socket


def server_loop(server_socket):
    """ the main server loop. sends back the information sent from the client """
    client_socket, address = server_socket.accept()
    protocol_send(client_socket, "Server Ready")

    while True:
        message = protocol_recv(client_socket)
        if message == "":
            break
        elif message == "Exit":
            break
        elif message == "Help":
            protocol_send(client_socket, HELP_STR)
        elif message == "Time":
            protocol_send(client_socket, str(datetime.now().time()))
        elif message == "Name":
            protocol_send(client_socket, "My name is Bobby!")
        elif message == "Rand":
            protocol_send(client_socket, str(random.randint(0, 1000)))
        else:
            protocol_send(client_socket, "Illegal Request")

    client_socket.close()
    server_socket.close()


def main():
    server_socket = create_server()
    server_loop(server_socket)


if __name__ == '__main__':
    main()
