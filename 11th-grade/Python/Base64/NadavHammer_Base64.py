__author__ = "Nadav Hammer"
""" A base64 encoder and decoder """


def chr_to_base64(c):
    """ converts a char from base64 index table to an ascii char """
    if 0 <= c <= 25:  # A - Z
        return chr(c + 65)
    elif 26 <= c <= 51:  # a - z
        return chr(c + 71)
    elif 52 <= c <= 61:  # 0 - 9
        return chr(c - 4)
    elif c == 62:
        return '+'
    elif c == 63:
        return '/'
    raise Exception("Unknown Character", c)


def base64_to_chr(c):
    """ converts an ascii char to a base64 index table char """
    if 65 <= c <= 90:  # A - Z
        return c - 65
    elif 97 <= c <= 122:  # a - z
        return c - 71
    elif 48 <= c <= 57:  # 0 - 9
        return c + 4
    elif c == 43:  # +
        return 62
    elif c == 47:  # /
        return 63
    elif c == 61:  # =
        return 0
    raise Exception("Unknown Character", c)


def base64_encode(data):
    """ encodes a string based on the base64 encoder """
    data = bytearray(data.encode())

    data_len = len(data)
    padding = 3 - (data_len % 3)
    if padding == 3:
        padding = 0
    if padding == 1:
        data.append(0)
    elif padding == 2:
        data.append(0)
        data.append(0)

    encoded = ""
    i = 0
    while i < data_len:
        encoded += chr_to_base64(data[i] >> 2)
        encoded += chr_to_base64(((data[i] & 0x3) << 4) | (data[i + 1] >> 4))
        encoded += chr_to_base64(((data[i + 1] & 0xf) << 2) | (data[i + 2] >> 6))
        encoded += chr_to_base64(data[i + 2] & 0x3f)
        i += 3

    if padding > 0:
        encoded = encoded[:-padding]
        encoded += padding * '='

    return encoded


def base64_decode(data):
    """ decodes a string based on the base64 decoder """
    data = bytearray(data.encode())

    for i in range(len(data)):
        data[i] = base64_to_chr(data[i])

    decoded = ""
    i = 0
    while i < len(data):
        decoded += chr((data[i] << 2) | (data[i + 1] >> 4))
        decoded += chr(((data[i + 1] & 0xf) << 4) | (data[i + 2] >> 2))
        decoded += chr(((data[i + 2] & 0x3) << 6) | (data[i + 3] & 0x3f))
        i += 4

    return decoded


def main():
    print(base64_encode("A"))
    print(base64_encode("AA"))
    print(base64_encode("AAA"))
    print(base64_encode("admin:password"))
    print(base64_decode("QQ=="))
    print(base64_decode("QUE="))
    print(base64_decode("QUFB"))
    print(base64_decode("YWRtaW46cGFzc3dvcmQ="))


if __name__ == '__main__':
    main()
