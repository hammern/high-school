__author__ = "Nadav Hammer"

import os


def main():
    os.chdir("C:/")
    print(os.getcwd())
    os.makedirs("./Nadav")
    os.chdir("./Nadav")
    print(os.getcwd())
    os.makedirs("./Hammer")
    os.makedirs("./Awesome")
    os.makedirs("./WhyNot")
    os.chdir("./WhyNot")
    print(os.getcwd())
    os.makedirs("./WhyYes")
    os.makedirs("./Euler")
    os.chdir("./Euler")
    print(os.getcwd())
    os.makedirs("./MathGod")
    os.makedirs("./GodHimself")


if __name__ == '__main__':
    main()
