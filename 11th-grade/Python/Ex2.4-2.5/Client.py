__author__ = "Nadav Hammer"
"""  """

import socket


def create_client():
    """ creates a client and tries to connect to a server """
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client_socket.connect(('127.0.0.1', 25565))
    response = client_socket.recv(1024)
    print(response.decode())
    return client_socket


def client_loop(client_socket):
    """ the main client loop. sends information to the server and receives information from the server """
    while True:
        data = input()
        client_socket.send(data.encode())
        answer = client_socket.recv(1024)
        print(answer.decode())
        if data == "quit":
            break

    client_socket.close()


def main():
    client_socket = create_client()
    client_loop(client_socket)


if __name__ == '__main__':
    main()
