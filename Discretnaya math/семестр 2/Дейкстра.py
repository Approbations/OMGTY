edges = list(map(int, input("Введите кол-во вершин, от какой считать минус 1: ").split()))
vertexes = [list(map(int, input().split())) for _ in range(int(edges[0]))]  # матрица весов
valid, weights = [True] * edges[0], vertexes[edges[1]].copy()
weights[edges[1]], valid[edges[1]] = 0, False
dct_path = dict()
for i in range(1, edges[0] + 1):
    dct_path[i] = [i]
for i in range(edges[0]):
    min_w, number_of_min_w = 10 ** 3 + 1, -1
    for j in range(edges[0]):
        if valid[j] and (weights[j] < min_w):
            min_w, number_of_min_w = weights[j], j
    for o in range(edges[0]):
        if weights[number_of_min_w] + vertexes[number_of_min_w][o] < weights[o]:
            weights[o] = weights[number_of_min_w] + vertexes[number_of_min_w][o]
            dct_path[o + 1] = [o + 1]
            dct_path[o + 1].extend(dct_path[number_of_min_w + 1])
    valid[number_of_min_w] = False
print(weights)
[dct_path[i].append(edges[1] + 1) for i in dct_path.keys() if edges[1] + 1 not in dct_path[i]]
print(dct_path)
