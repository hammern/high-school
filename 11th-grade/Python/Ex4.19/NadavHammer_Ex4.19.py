__author__ = "Nadav Hammer"
""" SMTP client """

import socket
import base64

DOMAIN = "networks.cyber.org.il"
SMTP_PORT = 587
BUFFER = 1024
NULL = "\x00"
USERNAME = "mail@gmail.com"
PASSWORD = "123456"
SEND_TO = "gmail@mail.com"
MAIL = "Subject: :)\r\n\r\nPython is a very cool language!\r\n.\r\n"


def create_client():
    """ creates a client and connects it to the server """
    client = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    client.connect((DOMAIN, SMTP_PORT))
    server_response = client.recv(BUFFER).decode()
    print(server_response)
    if server_response.split(" ")[0] != "220":
        return None
    return client


def build_authentication_response(username, password):
    """ builds an authentication message according to the correct syntax """
    auth = NULL + username + NULL + password
    auth = base64.b64encode(auth.encode()).decode()
    return "AUTH PLAIN " + auth + "\r\n"


def send_and_recv(sock, data):
    """ sends a message from the client and receives the next message from the server """
    sock.send(data.encode())
    response = sock.recv(BUFFER)
    print(response.decode())
    if response.decode().startswith("5"):
        sock.close()
        raise OSError
    return response


def handle(sock):
    """ main handler function for the client socket """
    try:
        send_and_recv(sock, "EHLO\r\n")
        send_and_recv(sock, build_authentication_response(USERNAME, PASSWORD))
        send_and_recv(sock, f"MAIL FROM:<{USERNAME}>\r\n")
        send_and_recv(sock, f"RCPT TO:{SEND_TO}\r\n")
        send_and_recv(sock, "DATA\r\n")
        send_and_recv(sock, MAIL)
        send_and_recv(sock, "QUIT\r\n")
    except OSError:
        pass


def main():
    sock = create_client()
    if sock is not None:
        handle(sock)
        sock.close()
    else:
        print("Connection Failed")


if __name__ == '__main__':
    main()
