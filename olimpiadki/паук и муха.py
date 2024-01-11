def plane(coords):
    global X, Y, Z
    x, y, z = coords
    lst = []
    if (x in range(X + 1)) and (y in range(Y + 1)) and (z == 0):
        lst.append('floor')
    if (x in range(X + 1)) and (y in range(Y + 1)) and (z == Z):
        lst.append('roof')
    if (x == 0) and (y in range(Y + 1)) and (z in range(Z + 1)):
        lst.append('left wall')
    if (x == X) and (y in range(Y + 1)) and (z in range(Z + 1)):
        lst.append('right wall')
    if (x in range(X + 1)) and (y == 0) and (z in range(Z + 1)):
        lst.append('front wall')
    if (x in range(X + 1)) and (y == Y) and (z in range(Z + 1)):
        lst.append('back wall')
    return lst


def length_vec(c1, c2):
    vec = [c1[0] - c2[0], c1[1] - c2[1], c1[2] - c2[2]]
    return (vec[0] ** 2 + vec[1] ** 2 + vec[-1] ** 2) ** 0.5


X, Y, Z = map(int, input().split())
spider = list(map(int, input().split()))
fly = list(map(int, input().split()))
length_vector = length_vector2 = 0

plane_spider = plane(spider)
plane_fly = plane(fly)
# для одной стены
flag = False
for i in plane_spider:
    if i in plane_fly:
        flag = True
        length_vector = round(length_vec(spider, fly), 3)
        length_vector2 = 10 ** 6
        print(length_vector)
        break


if len(plane_fly) == len(plane_spider) == 3:
    length_vector = (max(X, Y, Z) ** 2 + (Z + Y + X - max(X, Y, Z)) ** 2) ** 0.5
    length_vector2 = 10 ** 6

# для противоположных стен
if ('left wall' in plane_fly and 'right wall' in plane_spider) or \
        ('left wall' in plane_spider and 'right wall' in plane_fly):
    if 'left wall' in plane_fly:
        spider1 = [X + spider[2], spider[1], 0]
        fly1 = [-1 * fly[2], fly[1], 0]
        spider2 = [X + spider[2], spider[1], Z]
        fly2 = [-1 * fly[2], fly[1], Z]
    else:
        fly1 = [X + fly[2], fly[1], 0]
        spider1 = [-spider[2], spider[1], 0]
        fly2 = [X + Z - fly[2], fly[1], Z]
        spider2 = [spider[2] - Z, spider[1], Z]
elif ('front wall' in plane_fly and 'back wall' in plane_spider) or \
        ('front wall' in plane_spider and 'back wall' in plane_fly):
    if 'front wall' in plane_fly:
        fly1 = [fly[0], -1 * fly[2], 0]
        spider1 = [spider[0], Y + spider[2], 0]
        fly2 = [fly[0], -1 * fly[2], Z]
        spider2 = [spider[0], Y + spider[2], Z]
    else:
        spider1 = [spider[0], -spider[2], 0]
        fly1 = [fly[0], Y + fly[2], 0]
        spider2 = [spider[0], spider[2] - Z, Z]
        fly2 = [fly[0], Y + Z - fly[2], Z]
        spider3 = [X, spider[0] - X, spider[2]]
        fly3 = [X, Y + fly[0], fly[2]]
        spider4 = [0, -spider[0], spider[2]]
        fly4 = [0, fly[0], fly[2]]
        spider1 = spider3 if length_vec(spider1, fly1) > length_vec(spider3, fly3) else spider1
        fly1 = fly3 if spider1 == spider3 else fly1
        spider2 = spider4 if length_vec(spider2, fly2) > length_vec(spider4, fly4) else spider2
        fly2 = fly4 if spider2 == spider4 else fly2
elif ('floor' in plane_fly and 'roof' in plane_spider) or \
        ('floor' in plane_spider and 'roof' in plane_fly):
    if 'floor' in plane_fly:
        fly1 = fly.copy()
        spider1 = [spider[0], spider[1] + Z, 0]
        fly2 = [fly[0], fly[1] - Z, Z]
        spider2 = spider.copy()
    else:
        fly1 = [fly[0], fly[1] + Z, 0]
        spider1 = spider.copy()
        fly2 = fly.copy()
        spider2 = [spider[0], spider[1] - Z, Z]
else:
    # для соседних стен
    if length_vector == 0:
        length_vector = 10 ** 6
        if ('left wall' in plane_fly and 'roof' in plane_spider) or \
                ('left wall' in plane_spider and 'roof' in plane_fly):
            spider1 = [0, spider[1], spider[2] + spider[0]] if 'left wall' in plane_fly else [-spider[2], spider[1], Z]
        elif ('left wall' in plane_fly and 'floor' in plane_spider) or \
                ('left wall' in plane_spider and 'floor' in plane_fly):
            spider1 = [0, spider[1], -spider[0]] if 'left wall' in plane_fly else [-spider[2], spider[1], 0]
        elif ('left wall' in plane_fly and 'front wall' in plane_spider) or \
                ('left wall' in plane_spider and 'front wall' in plane_fly):
            spider1 = [0, -spider[0], spider[2]] if 'left wall' in plane_fly else [-spider[1], 0, spider[2]]
        elif ('left wall' in plane_fly and 'back wall' in plane_spider) or \
                ('left wall' in plane_spider and 'back wall' in plane_fly):
            spider1 = [0, Y + spider[0], spider[2]] if 'left wall' in plane_fly else [spider[1] - Y, Y, spider[2]]
        elif ('right wall' in plane_fly and 'roof' in plane_spider) or \
                ('right wall' in plane_spider and 'roof' in plane_fly):
            spider1 = [X, spider[1], Y + spider[0]] if 'right wall' in plane_fly else [X + Z - spider[2], spider[1], Z]
        elif ('right wall' in plane_fly and 'floor' in plane_spider) or \
                ('right wall' in plane_spider and 'floor' in plane_fly):
            spider1 = [X, spider[1], -spider[0]] if 'right wall' in plane_fly else [X + spider[2], spider[1], 0]
        elif ('right wall' in plane_fly and 'front wall' in plane_spider) or \
                ('right wall' in plane_spider and 'front wall' in plane_fly):
            spider1 = [X, spider[0] - X, spider[2]] if 'right wall' in plane_fly else [X + spider[1], 0, spider[2]]
        elif ('right wall' in plane_fly and 'back wall' in plane_spider) or \
                ('right wall' in plane_spider and 'back wall' in plane_fly):
            spider1 = [X, Y + X - spider[0], spider[2]] if 'right wall' in plane_fly else [X + Y - spider[1], Y, spider[2]]
        elif ('back wall' in plane_fly and 'roof' in plane_spider) or \
                ('back wall' in plane_spider and 'roof' in plane_fly):
            spider1 = [spider[0], Y + spider[2], Z] if 'roof' in plane_fly else [X, Y, Y - spider[1] + Z]
        elif ('front wall' in plane_fly and 'roof' in plane_spider) or \
                ('front wall' in plane_spider and 'roof' in plane_fly):
            spider1 = [spider[0], 0, spider[1] + Z] if 'front wall' in plane_fly else [spider[0], spider[2] - Z, Z]
        elif ('front wall' in plane_fly and 'floor' in plane_spider) or \
                ('front wall' in plane_spider and 'floor' in plane_fly):
            spider1 = [spider[0], 0, -spider[1]] if 'front wall' in plane_fly else [spider[0], -spider[2], 0]
        else:
            spider1 = [spider[0], Y, spider[1] - Y] if 'back wall' in plane_fly else [spider[0], Y + spider[2], 0]


        length_vector2 = length_vec(spider1, fly)


if length_vector == length_vector2 == 0:
    length_vector = length_vec(fly1, spider1)
    length_vector2 = length_vec(spider2, fly2)
    # print(length_vector, length_vector2)
if not flag:
    answer = min(length_vector, length_vector2)
    print(round(answer, 3))
