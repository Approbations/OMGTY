import copy


def right_calc():
    right_mini = [min(i) for i in matrix]
    for i in range(len(matrix)):
        matrix[i] = list(j - right_mini[i] for j in matrix[i])


def low_calc():
    low_mini = [min([matrix[j][i] for j in range(len(matrix))]) for i in range(len(matrix))]
    for i in range(len(matrix)):
        for j in range(len(matrix)):
            matrix[j][i] -= low_mini[i]


def degree_null():
    nulls = []
    [[nulls.append([i, j]) for j in range(len(matrix)) if matrix[i][j] == 0] for i in range(len(matrix))]
    degrees = []
    for null in nulls:
        s1 = sorted(copy.deepcopy(matrix[null[0]]))
        del s1[0]
        s2 = sorted([matrix[i][null[1]] for i in range(len(matrix))])
        del s2[0]
        degrees.append(min(s1) + min(s2))
    null = nulls[degrees.index(max(degrees))]
    path.append(still_here[0][null[0]] + 1)
    path.append(still_here[1][null[1]] + 1)
    olds = copy.deepcopy(path[-2:])
    if olds[1] - 1 in still_here[0] and olds[0] - 1 in still_here[1]:
        matrix[still_here[0].index(olds[1] - 1)][still_here[1].index(olds[0] - 1)] = float('inf')
    del still_here[0][null[0]]
    del still_here[1][null[1]]
    to_delete(null)


def to_delete(null):
    del matrix[null[0]]
    for i in matrix:
        del i[null[1]]


matrix = [[float('inf'), 41, 17, 23, 32],
          [13, float('inf'), 45, 12, 37],
          [80, 45, float('inf'), 50, 64],
          [23, 12, 50, float('inf'), 67],
          [32, 37, 64, 67, float('inf')]]
start_matrix = copy.deepcopy(matrix)
answer = 0
path, still_here = [], [[0, 1, 2, 3, 4], [0, 1, 2, 3, 4]]
while len(matrix) > 1:
    right_calc()
    low_calc()
    degree_null()
result = []
for i in range(0, len(path) - 1, 2):
    if path.count(path[i]) < 2:
        result.append(path[i])
        result.append(path[i + 1])
for i in range(0, len(path) - 1, 2):
    for j in range(0, len(path) - 1, 2):
        if result[len(result) - 1] == path[j]:
            result.append(path[j])
            result.append(path[j + 1])

for i in range(0, len(result) - 1, 2):
    if i == len(result) - 2:
        answer += start_matrix[result[i] - 1][result[i + 1] - 1] + start_matrix[result[i + 1] - 1][result[0] - 1]
    else:
        answer += start_matrix[result[i] - 1][result[i + 1] - 1]
print('Путь: ', end=" ")
[print(i, end=" ") for n, i in enumerate(result) if i != result[n - 1]]
print()
print("Длина маршрута: ", answer)
