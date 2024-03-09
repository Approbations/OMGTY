def cosy_list(list_of_num: list) -> list:
    lst = []
    for i in range(0, len(list_of_num), 2):
        lst.append([list_of_num[i], list_of_num[i + 1]])
    return lst


I = list(input().split())
dct = dict()
for name in I:
    dct[name] = 0
U = cosy_list(input().split())
weights = list(map(str, input().split()))
x = zip(U, weights)
now_flag = 1
total = 0
x = sorted(x, key=lambda tup: tup[1])
for pair in x:
    first, second, length = pair[0][0], pair[0][1], int(pair[1])
    if (dct[first] == 0) and (dct[second] == 0):
        dct[first] = dct[second] = now_flag
        now_flag += 1
        total += length
    elif dct[first] == 0 or dct[second] == 0:
        dct[first] = max(dct[first], dct[second])
        dct[second] = max(dct[first], dct[second])
        total += length
    elif dct[first] != dct[second]:
        to_change = [min(dct[first], dct[second]), max(dct[first], dct[second])]
        total += length
        for number in dct:
            if dct[number] == to_change[1]:
                dct[number] = to_change[0]
print(total)
