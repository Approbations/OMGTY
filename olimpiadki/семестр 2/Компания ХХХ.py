import copy


def employee(chief):
    ans = copy.deepcopy(dct[chief][1])
    chief = dct[chief][1]
    while chief:
        res = []
        for emp in chief:
            if len(dct[emp][1]) >= 1:
                ans.extend(dct[emp][1])
                res.extend(dct[emp][1])
        chief = copy.deepcopy(res)
    return sorted(ans)


def beauty_ans(ans):
    if len(ans) >= 1:
        for i in ans:
            print(f"{i} {dct[i][0]}")
    else:
        print('NO')


dct = dict()
flag = True
# dct[его номер] = [его имя, пешки]
prev = ''

while True:
    line = input().split(maxsplit=1)
    if line[0] == "END":
        break
    if line[0] in dct:
        dct[line[0]][0] = line[1] if dct[line[0]][0] == "Unknown Name" and len(line) == 2 else dct[line[0]][0]
    else:
        dct[line[0]] = [line[1] if len(line) == 2 else "Unknown Name", []]
    if flag:  # начальник
        flag = False
        prev = line[0]
    else:  # подчиненный
        flag = True
        dct[prev][1].append(line[0])

MainName = input()

if MainName.isdigit():
    beauty_ans(employee(MainName))
else:
    for key in dct:
        if dct[key][0] == MainName:
            MainName = key
            break
    beauty_ans(employee(MainName))
