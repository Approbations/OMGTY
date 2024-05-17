# golden fish не проходит последний тест
with open('input.txt', mode='r', encoding='UTF-8') as file:
    words = [file.readline() for _ in range(int(file.readline()))]
    for_start = [file.readline().split() for _ in range(int(file.readline()))]
    for_end = [file.readline().split() for _ in range(int(file.readline()))]
     dct_s, dct_e = dict(), dict()
    for i in for_start:
        dct_s[i[0]] = [int(i[1]), 0]
    for i in for_end:
        dct_e[i[0]] = [int(i[1]), 0]
    for word in words:
        if not ((word[0] in dct_s.keys()) is True == (word[-2] in dct_e.keys())):
            continue
        dct_s[word[0]][1] += 1
        dct_e[word[-2]][1] += 1
    print(min(sum(min(i) for i in dct_s.values()), sum(min(i) for i in dct_e.values())))
