def rotate(name_coord, number_block, direction_rotate):
    global positionX, positionY, positionZ
    direction_rotate, number_block = int(direction_rotate), int(number_block)
    if (name_coord == "X" and number_block != positionX) or \
            (name_coord == "Y" and number_block != positionY) or \
            (name_coord == "Z" and number_block != positionZ):
        return
    if name_coord == "X":
        coords = [positionZ, positionY]
        coords[1 if direction_rotate > 0 else 0] = N - coords[1 if direction_rotate > 0 else 0] + 1
        positionY, positionZ = coords[0], coords[1]
    elif name_coord == "Y":
        coords = [positionZ, positionX]
        coords[1 if direction_rotate > 0 else 0] = N - coords[1 if direction_rotate > 0 else 0] + 1
        positionX, positionZ = coords[0], coords[1]
    else:
        coords = [positionY, positionX]
        coords[1 if direction_rotate > 0 else 0] = N - coords[1 if direction_rotate > 0 else 0] + 1
        positionX, positionY = coords[0], coords[1]


file = open(r'C:\Users\Ekaterina\Downloads\Кубик Рубика\input_s1_20.txt', mode='r')
N, M = map(int, file.readline().split())
positionX, positionY, positionZ = map(int, file.readline().split())
[rotate(*file.readline().split()) for _ in range(M)]
print(positionX, positionY, positionZ)
