edges = input("Введите кол-во вершин через написать от какой вершины считать: ").split()
# матрица весов
vertexes = [list(map(int, input().split())) for _ in range(int(edges[0]))]
lamdas = [[0 if i + 1 == int(edges[1]) else 10 ** 9 for _ in range(int(edges[0]) + 1)] for i in range(int(edges[0]))]
prev_lst = [lamdas[u][0] for u in range(int(edges[0]))]
dct_paths = dict()
for i in range(1, int(edges[0]) + 1):
    dct_paths[i] = [i]

for i in range(1, int(edges[0])):
    now_list = []
    for j in range(int(edges[0])):
        mini = [10 ** 9, 0]
        for o in range(int(edges[0])):
            if vertexes[o][j] + lamdas[o][i - 1] < mini[0]:
                mini[0], mini[1] = vertexes[o][j] + lamdas[o][i - 1], o + 1
        lamdas[j][i] = min(mini[0], lamdas[j][i])
        if mini[0] < lamdas[j][i - 1]:
            dct_paths[j + 1] = [j + 1]
            dct_paths[j + 1].extend(dct_paths[mini[1]])
        now_list.append(lamdas[j][i])
    if prev_lst == now_list:
        break
    prev_lst = now_list.copy()
#проверка на отриц вес
flag = False
now_list = []
i += 1
for j in range(int(edges[0])):
    mini = [10 ** 9, 0]
    for o in range(int(edges[0])):
        if vertexes[o][j] + lamdas[o][i - 1] < mini[0]:
            mini[0], mini[1] = vertexes[o][j] + lamdas[o][i - 1], o + 1
    lamdas[j][i] = min(mini[0], lamdas[j][i])
    now_list.append(lamdas[j][i])
if prev_lst != now_list:
    print("Имеются отрицательные веса")
else:
    [print(f"{i}: {', '.join(list(map(str, dct_paths[i])))}") for i in dct_paths.keys()]
