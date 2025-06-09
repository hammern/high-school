__author__ = "Roy, Ido, Benjamin and Nadav Hammer"
"""  """

import string
import itertools
import functools

A = 1103515245
C = 12345
M = pow(2, 32)


# def turn_to_number(password):
#     lst = []
#     for ch in password:
#        lst.append(ord(ch))
#     to_seed = 1
#     for num in lst:
#         to_seed *= num
#     return to_seed % (pow(2, 32))


def turn_to_number(password):
    return functools.reduce(lambda a, b: a * b, [ord(ch) for ch in password]) % pow(2, 32)


# def lcg(seed, length):
    # lst_rand = []
    # x = seed
    # for i in range(length):
    #     x = (A * x + C) % M
    #     lst_rand.append((x // 256) % 256)
    # return lst_rand


def seeder(seed):
    while (seed := (A * seed + C) % M) >= 0: yield seed


def lcg(seed, length):
    return [s // 256 % 256 for s, _ in zip(seeder(seed), range(length))]


def encrypt_xor(lcg_list, inp):
    return [ord(c) ^ l for c, l in zip(inp, itertools.cycle(lcg_list))]


def decrypt_xor(lcg_list, nums):
    return "".join([chr(n ^ l) for n, l in zip(nums, itertools.cycle(lcg_list))])


def main():
    password = "MyPa$$w0rd"
    print(f"Plain: {password}")
    seed = turn_to_number(password)
    print("Seed:", seed)
    lcg_list = lcg(seed, len(password))
    print("LCG:", lcg_list)
    enc = encrypt_xor(lcg_list, password)
    print("Encrypted:", enc)

    dec = decrypt_xor(lcg_list, enc)
    for c in dec:
        if c not in string.printable:
            print("Error: encrypted text isn't printable")
            break
    print(f"Decrypted: {dec}")


if __name__ == '__main__':
    main()
