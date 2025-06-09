# D. Given a list of numbers, return a list where
# all adjacent == elements have been reduced to a single element,
# so [1, 2, 2, 3] returns [1, 2, 3]. You may create a new list or
# modify the passed in list.


def remove_adjacent(nums):
    final_list = []
    for num in nums:
        if num not in final_list:
            final_list.append(num)
    return final_list


# E. Given two lists sorted in increasing order, create and return a merged
# list of all the elements in sorted order. You may modify the passed in lists.
# Ideally, the solution should work in "linear" time, making a single
# pass of both lists.
#
# NOTE - DO NOT use return sorted(sorted1 + sorted2) - that's too easy :-)
#
def linear_merge(sorted1, sorted2):
    sorted_list = []
    i = 0
    j = 0
    while i < len(sorted1) and j < len(sorted2):
        if sorted1[i] <= sorted2[j]:
            sorted_list.append(sorted1[i])
            i += 1
        else:
            sorted_list.append(sorted2[j])
            j += 1
    if i < len(sorted1):
        for k in range(i, len(sorted1)):
            sorted_list.append(sorted1[k])
    else:
        for k in range(j, len(sorted2)):
            sorted_list.append(sorted2[k])
    return sorted_list


def test(got, expected):
    """ simple test() function used in main() to print
        what each function returns vs. what it's supposed to return. """
    if got == expected:
        prefix = " OK "
    else:
        prefix = "  X "
    print("%s got: %s expected: %s" % (prefix, repr(got), repr(expected)))


def main():
    """ main() calls the above functions with interesting inputs,
        using test() to check if each result is correct or not. """

    print("\nremove_adjacent")
    test(remove_adjacent([1, 2, 2, 3]), [1, 2, 3])
    test(remove_adjacent([2, 2, 3, 3, 3]), [2, 3])
    test(remove_adjacent([]), [])

    print("\nlinear_merge")
    test(linear_merge(["aa", "xx", "zz"], ["bb", "cc"]), ["aa", "bb", "cc", "xx", "zz"])
    test(linear_merge(["aa", "xx"], ["bb", "cc", "zz"]), ["aa", "bb", "cc", "xx", "zz"])
    test(linear_merge(["aa", "aa"], ["aa", "bb", "bb"]), ["aa", "aa", "aa", "bb", "bb"])


if __name__ == "__main__":
    main()
