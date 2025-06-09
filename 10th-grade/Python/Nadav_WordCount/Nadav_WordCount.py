__author__ = "Nadav Hammer"
""" Gets a text file and counts the amount of words in it in two different ways:
    1 - How many times the words appears in the file.
    2 - The top 20 most used words.
    The result is written into a file. """

import sys
import argparse


def parse_cmd(args_list):
    """ Validates the arguments given from the command line """
    num_of_words = 0
    parser = argparse.ArgumentParser()
    parser.add_argument("--count", action="count",
                        help="Counts all of the words in the file")
    parser.add_argument("--topcount", action="count",
                        help="Counts the top 20 most used words in the file")
    parser.add_argument("output_file_name", type=str, nargs='+',
                        help="File to output")
    args = parser.parse_args(args_list)
    if args.topcount:
        num_of_words = 20
    return num_of_words, args.output_file_name[0]


def count_words():
    """ Counts the words """
    words = {}
    with open("alice.txt", "r") as file:
        for line in file:
            for word in split_line(line):
                word = clear_word(word)
                if word:
                    if word in words.keys():
                        words[word] += 1
                    else:
                        words[word] = 1
    return words


def split_line(line):
    """ Splits the line and clears any words connected with - """
    words = []
    for word in line.split(" "):
        words += word.split("-")
    return words


def clear_word(word):
    """ Clears a word of any unwanted chars """
    unwanted_chars = "\n!?`,.:;()*\"[]"
    for c in unwanted_chars:
        word = word.replace(c, "").lower()
    if word[-1:] == "'":
        word = word[:-1]
    return word


def write_words(words, output_file_name, num_of_words):
    """ Writes the amount of words in the file """
    with open(output_file_name, "w") as file:
        all_words = sorted(words, key=words.get, reverse=True)
        if num_of_words > 0:
            all_words = all_words[:num_of_words]
        for word in all_words:
            file.write("{} - {}\n".format(word, words[word]))


def main():
    num_of_words, output_file_name = parse_cmd(sys.argv[1:])
    if output_file_name:
        words = count_words()
        write_words(words, output_file_name, num_of_words)


if __name__ == '__main__':
    main()
