def rotate(name_coord, number_block, direction_rotate):
    global positionX, positionY, positionZ
    direction_rotate, number_block = int(direction_rotate), int(number_block)
    if (name_coord == "X" and number_block != positionX) or \
            (name_coord == "Y" and number_block != positionY) or \
            (name_coord == "Z" and number_block != positionZ):
        return
    if name_coord == "X":
        coord, change1, change2 = [positionX, positionZ, positionY], 2, 1
    elif name_coord == "Y":
        coord, change1, change2 = [positionZ, positionY, positionX], 2, 0
    else:
        coord, change1, change2 = [positionY, positionX, positionZ], 1, 0
    coord[change1 if direction_rotate > 0 else change2] = N - coord[change1 if direction_rotate > 0 else change2] + 1
    positionX, positionY, positionZ = coord


file = open(r'C:\Users\Ekaterina\Downloads\Кубик Рубика\input_s1_20.txt', mode='r')
N, M = map(int, file.readline().split())
positionX, positionY, positionZ = map(int, file.readline().split())
[rotate(*file.readline().split()) for _ in range(M)]
print(positionX, positionY, positionZ)
