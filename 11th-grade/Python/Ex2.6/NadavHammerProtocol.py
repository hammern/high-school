__author__ = "Nadav Hammer"
""" protocols for server and client """


def protocol_send(socket, message):
    """ protocol for sending a message """
    response = message.encode()
    len_str = "{:04d}".format(len(response)).encode()

    try:
        socket.send(len_str)
        socket.send(response)
    except ConnectionAbortedError:
        return -1
    except ConnectionResetError:
        return -1

    return len(len_str) + len(response)


def protocol_recv(socket):
    """ protocol for receiving a message """
    try:
        response_len = socket.recv(4)
        if not response_len:
            response_len = "0".encode()
        response_len = int(response_len.decode())
        if response_len > 0:
            response = socket.recv(response_len)
        else:
            response = "".encode()
    except ConnectionAbortedError:
        response = "".encode()
    return response.decode()
