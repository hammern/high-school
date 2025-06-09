__author__ = "Roy, Ido and Nadav H"
""" One line exercises """

from functools import reduce


def avg_diff(lst1, lst2):
    return sum([abs(lst1[i] - lst2[i]) for i in range(len(lst1))]) / len(lst1)


def avg_diff_with_zip(lst1, lst2):
    return sum([abs(i - j) for i, j in zip(lst1, lst2)]) / min(len(lst1), len(lst2))


def anti_b(with_b):
    return ''.join([ch for ch in with_b if ch != 'b'])


def main():
    # ---------------------- List Comprehension
    lst1 = [1, 1, 1, 1, 1]
    lst2 = [1, 2, 3, 4, 5]
    print(avg_diff(lst1, lst2))
    print(avg_diff_with_zip(lst1, lst2))

    with_b = "abc"
    print(anti_b(with_b))

    # ---------------------- Lambda
    print((lambda num: num + 2)(2))

    # interpretation 1: values do not need to be absolute and sorted by digit
    print(sorted([2, -8, 5, -6, -1, 3], key=lambda num: -num if num < 0 else num))

    # interpretation 2: values need to be absolute and sorted by value
    print(sorted(map(lambda num: -num if num < 0 else num, [2, -8, 5, -6, -1, 3])))

    # ---------------------- Map
    print(''.join(map(lambda ch: ch * 2, "Hello")))

    # ---------------------- Filter
    print(list(filter(lambda num: num % 3 == 0, [i for i in range(1, 19)])))

    # ---------------------- Reduce
    print(reduce(lambda x, y: x + y, list(map(int, str(1234)))))


if __name__ == '__main__':
    main()
