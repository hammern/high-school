__author__ = "Nadav Hammer"
""" repeats the message the client sends """

import socket
import sys


def create_server():
    """ creates a server and listens for a client """
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind(("0.0.0.0", 25565))
    server_socket.listen(1)
    return server_socket


def server_loop(server_socket):
    """ the main server loop. sends back the information sent from the client """
    client_socket, address = server_socket.accept()
    client_socket.send("Server Ready".encode())

    while True:
        data = client_socket.recv(1024)
        if data.decode() == "quit":
            break
        client_socket.send(data)

    client_socket.close()
    server_socket.close()


def main():
    server_socket = create_server()
    server_loop(server_socket)


if __name__ == '__main__':
    main()
