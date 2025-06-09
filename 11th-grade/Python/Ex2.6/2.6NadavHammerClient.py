__author__ = "Nadav Hammer"
"""  """

import socket
from NadavHammerProtocol import *

IP = "127.0.0.1"
PORT = 25565


def create_client():
    """ creates a client and tries to connect to a server """
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    try:
        client_socket.connect((IP, PORT))
        response = protocol_recv(client_socket)
        if not response:
            raise Exception("No response")
        print(response)
    except Exception as e:
        print("Error connecting to server: ", e)
        client_socket.close()
        client_socket = None
    return client_socket


def client_loop(client_socket):
    """ the main client loop. sends information to the server and receives information from the server """
    print("Type Help for help")
    while True:
        data = input("> ")
        if data:
            r = protocol_send(client_socket, data)
            if r < 0:
                print("Error, no response from server")
                break
            response = protocol_recv(client_socket)
            if not response or data == "Exit":
                break
            print(response)

    client_socket.close()


def main():
    client_socket = create_client()
    if client_socket:
        client_loop(client_socket)


if __name__ == '__main__':
    main()
