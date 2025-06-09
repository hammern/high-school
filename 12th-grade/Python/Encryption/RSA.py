__author__ = "Benjamin, Roy, Ofek, (pilot) Ido and Nadav Hammer"
"""  """

from Crypto.PublicKey import RSA
from Crypto.Cipher import PKCS1_OAEP


def main():
    message = input("Please input a message: ").encode()
    key = RSA.generate(2048)

    public_key = key.publickey().exportKey()
    private_key = key.exportKey()
    print(public_key)
    print(private_key)

    cipher = PKCS1_OAEP.new(RSA.importKey(public_key))
    enc_message = cipher.encrypt(message)
    print(enc_message)

    cipher = PKCS1_OAEP.new(RSA.importKey(private_key))
    dec_message = cipher.decrypt(enc_message)
    print(dec_message)


if __name__ == '__main__':
    main()

