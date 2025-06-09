__author__ = "Nadav Hammer"
""" Get exercise file, verifies it and writes the answer to a result file.
    If the file is illegal it writes in the answer illegal file. """


import sys
import os


def check_correct_parameters():
    """ Checks if the number of parameters given by the command line is 2 """
    if len(sys.argv) == 1:
        print("Error - No parameters given")
        correct_parameters = False
    elif len(sys.argv) == 2:
        print("Error - Only one parameter given")
        correct_parameters = False
    elif len(sys.argv) > 3:
        print("Error - Too many parameters given")
        correct_parameters = False
    else:
        correct_parameters = True
    return correct_parameters


def read_file():
    """ returns all of the exercises from the exercises file """
    ex_file = sys.argv[1]
    all_exercises = []
    if os.path.isfile(ex_file):
        with open(ex_file, "r") as file:
            for exercise in file:
                all_exercises.append(exercise.replace("\n", ""))
    else:
        print("Error - The exercise file does not exist")
    return all_exercises


def do_plus(num1, num2):
    """ Adds the two parameters """
    return num1 + num2


def do_minus(num1, num2):
    """ Deducts the two parameters """
    return num1 - num2


def do_multiply(num1, num2):
    """ Multiplies the two parameters """
    return num1 * num2


def do_div(num1, num2):
    """ Divides the two parameters. If there is division by zero, returns illegal exercise """
    if num2 == 0:
        return "illegal exercise"
    else:
        return num1 / num2


def calc_exercise(exercise):
    """ Calculates the result of the exercise """
    split_exercise = exercise.split(" ")
    if len(split_exercise) != 3:
        return "illegal exercise"
    elif not (split_exercise[0].isdigit()) or not (split_exercise[2].isdigit()):
        return "illegal exercise"
    else:
        num1 = int(split_exercise[0])
        num2 = int(split_exercise[2])
        operator = split_exercise[1]
        if operator == "+":
            return do_plus(num1, num2)
        elif operator == "-":
            return do_minus(num1, num2)
        elif operator == "*":
            return do_multiply(num1, num2)
        elif operator == "/":
            return do_div(num1, num2)
        else:
            return "illegal exercise"


def write_results(final_output):
    """ Writes all of the results in the results file """
    with open(sys.argv[2], "w") as file:
        for result in final_output:
            file.write(result)


def main():
    final_output = []
    if check_correct_parameters():
        all_exercises = read_file()
        for exercise in all_exercises:
            final_output.append(exercise + " = " + str(calc_exercise(exercise)) + "\n")
        write_results(final_output)


if __name__ == '__main__':
    main()
