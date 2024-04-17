import copy


def find_min(my_cell):
    set_of_points = set()
    [set_of_points.add(matrix[i[0]][i[1]]) for i in find_cells(my_cell)]
    set_of_points.remove(-1)
    return min(set_of_points)


def find_cells(my_cell):
    return [[my_cell[0] - 1, my_cell[1] - 1], [my_cell[0] - 1, my_cell[1]], [my_cell[0] - 1, my_cell[1] + 1],
            [my_cell[0], my_cell[1] - 1], [my_cell[0], my_cell[1] + 1],
            [my_cell[0] + 1, my_cell[1] - 1], [my_cell[0] + 1, my_cell[1]], [my_cell[0] + 1, my_cell[1] + 1]]


lot = int(input('кол-во стобцов матрицы с учетом стенок: '))  # -1 - стенка, 1000 - пустая клетка
matrix = [list(map(int, input().split())) for _ in range(lot)]
prev_matrix = copy.deepcopy(matrix)
# сначала задается строка и потом столбец
start = list(map(int, input('координаты откуда начинаем через пробел (отсчет с 0): ').split()))
finish = list(map(int, input('координаты куда идем через пробел (отсчет 0): ').split()))
matrix[start[0]][start[1]] = 0
point = 0
for_check = list()
for_check.append(start)
flag = True
while matrix[finish[0]][finish[1]] == 1000:
    point += 1
    new_check = list()
    for cell in for_check:
        lst = find_cells(cell)
        for check in lst:
            if matrix[check[0]][check[1]] <= 0:
                continue
            mini = min(matrix[check[0]][check[1]], find_min(check))
            matrix[check[0]][check[1]] = min(point, matrix[check[0]][check[1]]) \
                if mini < 1000 else matrix[check[0]][check[1]]
            if prev_matrix[check[0]][check[1]] != matrix[check[0]][check[1]]:
                new_check.append(check)
    for_check = copy.deepcopy(new_check)
    if matrix == prev_matrix:
        flag = False
        print('путей нет')
        break
    prev_matrix = copy.deepcopy(matrix)

if flag:
    prev_matrix = [['_' if cell > 0 else cell for cell in row] for row in prev_matrix]
    prev_matrix[finish[0]][finish[1]] = point
    while True:
        point -= 1
        cells = find_cells(finish)
        path_cells = [matrix[i[0]][i[1]] for i in cells]
        finish = [cells[path_cells.index(point)][0], cells[path_cells.index(point)][1]]
        prev_matrix[finish[0]][finish[1]] = point
        if point == 0:
            break
    print('один из возможных путей')
    print(*prev_matrix, sep='\n')
