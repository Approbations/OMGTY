def getStrL(N, arr):
    OutArr = list()
    if (arr is None) or (len(arr) == 0) or (N <= 0):
        return None
    for i in range(len(arr)):
        getStr(OutArr, str(arr[i]), N - 1, dct[i])
    return OutArr


def getStr(OutArr, strAppend, N, arr):
    if strAppend in OutArr:
        return None
    if N == 0:
        OutArr.append(strAppend)
        return None
    for i in range(len(arr)):
        if str(arr[i]) in strAppend:
            continue
        getStr(OutArr, strAppend + str(arr[i]), N - 1, dct[arr[i]])


lot = int(input('кол-во стобцов матрицы: '))
matrix = [list(map(int, input().split())) for _ in range(lot)]
dct = dict()
for i in range(lot):
    dct[i] = [n for n, j in enumerate(matrix[i]) if j == 1]
# ответы все для самой первой вершины
res = getStrL(6, dct[0])
for i in res:
    if '0' in i:
        continue
    if matrix[int(i[-1])][0] == 1:
        print("Цикл", "1" + ''.join(list(map(lambda x: str(int(x) + 1), list(i)))))
    else:
        print("Путь", "1" + ''.join(list(map(lambda x: str(int(x) + 1), list(i)))))
