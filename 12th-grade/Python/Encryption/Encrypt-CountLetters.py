__author__ = "Ido, Ofek and Nadav Hammer"
"""  """

import string
from collections import defaultdict

LETTERS = {}
DECYPHER_LETTERS = {}
KEY = 1

# COUNT_LETTERS = dict.fromkeys(string.ascii_lowercase, 0)
COUNT_LETTERS = defaultdict(int)
TOTAL = 0


def fill_letters():
    for i in range(len(string.ascii_lowercase)):
        LETTERS[string.ascii_lowercase[i]] = string.ascii_lowercase[(i + KEY) % len(string.ascii_lowercase)]
        DECYPHER_LETTERS[string.ascii_lowercase[i]] = string.ascii_lowercase[(i - KEY) % len(string.ascii_lowercase)]


def encrypt(to_encrypt):
    encrypted = ""
    for letter in to_encrypt:
        encrypted += LETTERS[letter]
    return encrypted


def decrypt(to_decrypt):
    decrypted = ""
    for letter in to_decrypt:
        decrypted += DECYPHER_LETTERS[letter]
    return decrypted


def count_words():
    """ Counts the words """
    words = defaultdict(int)
    with open("nytimes_news_articles.txt", "r", encoding="utf-8") as file:
        for line in file:
            for word in split_line(line):
                word = clear_word(word)
                if word:
                    words[word] += 1
    return words


def count_letters(words):
    """ Counts the words """
    global TOTAL
    for word in words:
        for letter in word.lower():
            TOTAL += words[word]
            COUNT_LETTERS[letter] += words[word]


def split_line(line):
    """ Splits the line and clears any words connected with - """
    words = []
    for word in line.split(" "):
        words += word.split("-")
    return words


def clear_word(word):
    """ Clears a word of any unwanted chars """
    for letter in word.lower():
        if letter not in string.ascii_lowercase:
            word = word.replace(letter, "").lower()
    return word


def print_letter_statistics():
    print("Word Statistics:")
    sorted_letters = list(COUNT_LETTERS.items())
    sorted_letters.sort(key=lambda k: k[1], reverse=True)
    for letter in sorted_letters:
        if percentage := round(100 * (letter[1]/TOTAL), 3):
            print(f"{letter[0]} -> {percentage}%")


def main():
    fill_letters()
    print(LETTERS)
    print(DECYPHER_LETTERS)
    to_encrypt = "abc"
    print(encrypt(to_encrypt))
    print(decrypt(encrypt(to_encrypt)))

    words = count_words()
    count_letters(words)
    print(COUNT_LETTERS)
    print_letter_statistics()


if __name__ == '__main__':
    main()
