edges = list(map(int, input("Введите кол-во вершин, от какой, до какой вершины считать: ").split()))
vertexes = [list(map(int, input().split())) for _ in range(int(edges[0]))]  # матрица весов
valid, weights = [True] * edges[0], vertexes[edges[1]].copy()
weights[edges[1]], valid[edges[1]] = 0, False
for i in range(edges[0]):
    min_w, number_of_min_w = 10 ** 3 + 1, -1
    for j in range(edges[0]):
        if valid[j] and (weights[j] < min_w):
            min_w, number_of_min_w = weights[j], j
        for o in range(edges[0]):
            if weights[number_of_min_w] + vertexes[number_of_min_w][o] < weights[o]:
                weights[o] = weights[number_of_min_w] + vertexes[number_of_min_w][o]
                valid[j] = False
print(f"Минимальный путь от вершины {edges[1]} до вершины {edges[2]}: ", weights[edges[2] - 1])
