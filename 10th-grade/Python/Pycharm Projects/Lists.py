__author__ = "Nadav Hammer"
""" List exercises """


def summer(list1):
    sum1 = list1[0]
    for i in range(1, len(list1)):
        sum1 += list1[i]
    return "All of the items of the list together are: " + str(sum1)


def main():
    list1 = ['a', 'b', 'c']
    list2 = [1, 3, 8]
    print(summer(list1))


if __name__ == '__main__':
    main()
