__author__ = "Nadav Hammer"
""" A python web server program """

import socket
import os


SERVER_IP = '127.0.0.1'
SERVER_PORT = 80
REQUEST_BUFFER = 4096
SERVER_HTTP_VERSION = "HTTP/1.0"

MOVED_FILES = {
    "page1.html": "index.html",
    "index.htm": "index.html"
}

HTTP_RESPONSE_STR = {
    "200": "OK",
    "302": "Moved Temporarily",
    "403": "Forbidden",
    "404": "Not Found",
    "500": "Internal Server Error"
}

CONTENT_TYPES = {
    "html": "text/html; charset=utf-8",
    "txt": "text/html; charset=utf-8",
    "jpg": "image/jpeg",
    "js": "text/javascript; charset=UTF-8",
    "css": "text/css",
    "ico": "image/x-icon"
}


class MovedError(Exception):
    """ exception to handle Temporary Moved files """
    def __init__(self, new_file):
        self.new_file = new_file


def create_server():
    """ creates a server and listens for a client """
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((SERVER_IP, SERVER_PORT))
    server_socket.listen(1)
    return server_socket


def parse_http_request(request):
    """ parse and verify the http request
        returns the requested file name """
    lines = request.split("\r\n")
    method, path, protocol_ver = lines[0].split(" ")
    if method != "GET":
        raise Exception("Unknown method: " + method)
    if protocol_ver != "HTTP/1.1" and protocol_ver != "HTTP/1.0":
        raise Exception("Unknown protocol version: " + protocol_ver)
    return path


def build_http_response(code, length=0, content_type="", headers=None):
    """ builds and adds headers an http response """
    try:
        response = SERVER_HTTP_VERSION + " " + code + " " + HTTP_RESPONSE_STR[code] + "\r\n"
    except KeyError:
        response = SERVER_HTTP_VERSION + " 500 " + HTTP_RESPONSE_STR["500"] + "\r\n"
    if length > 0:
        response += "Content-Length: " + str(length) + "\r\n"
    if content_type != "":
        response += "Content-Type: " + content_type + "\r\n"
    if type(headers) == list:
        for header in headers:
            response += header[0] + ": " + header[1] + "\r\n"
    print(response)
    response += "\r\n"
    return response.encode()


def http_send_file(s, file, content_type=""):
    """ sends a file to the client """
    s.send(build_http_response("200", len(file), content_type))
    s.sendall(file)


def get_content_type(path):
    """ returns the content type based on file extension """
    try:
        ext = path.split(".")[-1]
        t = CONTENT_TYPES[ext]
    except KeyError:
        t = ""
    return t


def parse_path(path):
    file_name = path.split(os.path.sep)[-1]
    parts = file_name.split("?")
    file_name = parts[0]
    params = None
    if len(parts) > 1:
        params = parts[1:]
    if params:
        param_name, param_value = params[0].split("=")
        params = {param_name: param_value}
    return file_name, params


def calculate_next(sock, params):
    if "num" in params:
        response = str(int(params["num"]) + 1).encode()
        sock.send(build_http_response("200", len(response), CONTENT_TYPES["txt"]))
        sock.send(response)


def server_loop(server_socket):
    """ main server loop """
    global client_socket
    while True:
        try:
            print("Server Waiting...")
            client_socket, address = server_socket.accept()
            print("Received Connection:", address)
            request = client_socket.recv(REQUEST_BUFFER)
            path = parse_http_request(request.decode())
            if path[-1] == "/":
                path += "index.html"
            path = os.getcwd() + path.replace('/', os.path.sep)
            file_name, params = parse_path(path)
            print(file_name, params)
            if file_name in MOVED_FILES:
                raise MovedError(MOVED_FILES[file_name])
            elif file_name == "calculate-next":
                calculate_next(client_socket, params)
            else:
                with open(path, "rb") as file:
                    f = file.read()
                    http_send_file(client_socket, f, get_content_type(path))
        except MovedError as e:
            new_url = "http://" + SERVER_IP + ":" + str(SERVER_PORT) + "/" + e.new_file
            client_socket.send(build_http_response("302", headers=[["Location", new_url]]))
        except PermissionError:
            client_socket.send(build_http_response("403"))
        except FileNotFoundError:
            client_socket.send(build_http_response("404"))
        except KeyboardInterrupt:
            break
        except socket.timeout:
            print("Socket timeout")
            pass
        except Exception as e:
            client_socket.send(build_http_response("500"))
            client_socket.send(str(e).encode())
            print(e)
        client_socket.close()

    server_socket.close()


def main():
    server_socket = create_server()
    server_loop(server_socket)


if __name__ == '__main__':
    main()
