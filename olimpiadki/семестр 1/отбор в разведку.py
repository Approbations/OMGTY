from math import ceil


def recursion(lot):
    if lot == 3:
        return 1
    elif lot < 3 or lot == 4:
        return 0
    return recursion(lot // 2) + recursion(ceil(lot / 2))


print(recursion(int(input())))
