__author__ = "Noam, Guy and Nadav Hammer"
"""  """

import string

LETTERS = string.ascii_letters
KEY = "abcd"


def encrypt(to_encrypt):
    encrypted = ""
    i = 0
    for char in to_encrypt:
        if i >= len(KEY):
            i = 0
        if char not in LETTERS:
            encrypted += char
        else:
            encrypted += LETTERS[(LETTERS.find(char) + LETTERS.find(KEY[i])) % len(LETTERS)]
        i += 1
    return encrypted


def decrypt(to_decrypt):
    decrypted = ""
    i = 0
    for char in to_decrypt:
        if i >= len(KEY):
            i = 0
        if char not in LETTERS:
            decrypted += char
        else:
            decrypted += LETTERS[(LETTERS.find(char) - LETTERS.find(KEY[i])) % len(LETTERS)]
        i += 1
    return decrypted


def main():
    to_encrypt = "Hello World"

    encrypted = encrypt(to_encrypt)
    print(encrypted)

    decrypted = decrypt(encrypted)
    print(decrypted)


if __name__ == '__main__':
    main()
