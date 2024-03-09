def cosy_list(list_of_num: list) -> list:
    lst = []
    for i in range(0, len(list_of_num), 2):
        lst.append([list_of_num[i], list_of_num[i + 1]])
    return lst


def find_shortest() -> int:
    mini = 10 ** 5
    ind = 0
    for num, name_v in enumerate(lst_of_v):
        if name_v is False:
            continue
        name_v = I[num]
        for n, i in enumerate(x):
            if (name_v in i[0]) and (mini > i[1]) and (lst_of_v[I.index(i[0][0])] != lst_of_v[I.index(i[0][1])]):
                mini = i[1]
                ind = n
    return ind


I = list(input().split())
U = cosy_list(input().split())
weights = list(map(int, input().split()))
x = list(zip(U, weights))
print(x)
total = 0
lst_of_v = [False for name in I]
lst_of_v[0] = True
while lst_of_v.count(True) != len(I):
    ind_of_shortest = find_shortest()
    total += x[ind_of_shortest][1]
    lst_of_v[I.index(x[ind_of_shortest][0][0])], lst_of_v[I.index(x[ind_of_shortest][0][1])] = True, True
print(total)
