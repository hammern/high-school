__author__ = "Benjamin, Roy, Ofek, (pilot) Ido and Nadav Hammer"
"""  """

import hashlib
import os

URANDOM_SIZE = 10
HASH_ITERATIONS = 100000


def create_hash(password, salt):
    return hashlib.pbkdf2_hmac('sha256', password, salt, HASH_ITERATIONS)


def main():
    salt = os.urandom(URANDOM_SIZE)
    print("Salt:", salt)

    password = input("Please enter your password: ").encode()
    enc_password = create_hash(password, salt)
    print("Encrypted password:", enc_password)

    password = input("Please enter your password again: ").encode()
    second_enc_password = create_hash(password, salt)
    print("Second encrypted password:", second_enc_password)

    if enc_password == second_enc_password:
        print("Logged in successfully")
    else:
        print("Wrong password")


if __name__ == '__main__':
    main()
