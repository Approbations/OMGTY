import copy
vertexes = list(map(int, input("Введите кол-во вершин, от какой, до какой вершины считать: ").split()))
matrix = [list(map(int, input().split())) for _ in range(int(vertexes[0]))]  # матрица весов
weights = copy.deepcopy(matrix)

prev = [[None if matrix[i][j] == 10 ** 3 else i for j in range(vertexes[0])] for i in range(vertexes[0])]

for i in range(vertexes[0]):
    for j in range(vertexes[0]):
        for z in range(vertexes[0]):
            if weights[j][i] + weights[i][z] < weights[j][z]:
                weights[j][z] = weights[j][i] + weights[i][z]
                prev[j][z] = prev[i][z]
print(*weights, sep='\n')
print(f"Длина пути из {vertexes[2]} в {vertexes[1]}")
print(weights[vertexes[1] - 1][vertexes[2] - 1])

path = []
vertexes[1] -= 1
while (vertexes[1] is not None) and (vertexes[1] not in path):
    path.append(vertexes[1])
    vertexes[1] = prev[vertexes[2] - 1][vertexes[1]]
path = path[::-1]
print(f"пути из {vertexes[2]} в {vertexes[1]}")
print(*list(map(lambda x: x + 1, path)))
