with open('input_s1_01.txt', mode='r') as file:
    data = file.readline()
    x, y, l, c1, c2, c3, c4, c5, c6 = map(int, data.split())
    P = 2 * (x + y)
    ostat = 0
    if l > max(x, y):
        if l > P:
            wall_good = (l - P) * (c2 + c6) + min(max(x, y) * c1 + (P - max(x, y)) * (c2 + c3),
            max(x, y) * c1 + (P - max(x, y)) * (c2 + c4 + c5 + c6),
            max(x, y) * (c2 + c3) + (P - max(x, y)) * (c2 + c4 + c5 + c6),
            max(x, y) * (c2 + c4 + c5 + c6) + (P - max(x, y)) * (c2 + c3), P * (c2 + c4 + c5 + c6), P * (c2 + c3),
            min(x, y) * c1 + (P - min(x, y)) * (c2 + c3), min(x, y) * c1 + (P - min(x, y)) * (c2 + c4 + c5 + c6),
            min(x, y) * (c2 + c3) + (P - min(x, y)) * (c2 + c4 + c5 + c6),
            min(x, y) * (c2 + c4 + c5 + c6) + (P - min(x, y)) * (c2 + c3))
        else:
            ostat = l - max(x, y)
            wall_good = min(max(x, y) * c1 + ostat * (c2 + c4 + c5 + c6),
                        ostat * (c2 + c3) + max(x, y) * (c2 + c4 + c5 + c6),
                        max(x, y) * (c2 + c3) + ostat * (c2 + c4 + c5 + c6), max(x, y) * c1 + ostat * (c2 + c3),
                    l * (c2 + c3), l * (c2 + c4 + c5 + c6))
            walls = P - l
            other_wall = walls * (c4 + c5)
    if l <= max(x, y):
        wall_good = min(l * c1, l * (c2 + c3), l * (c2 + c4 + c5 + c6))
        walls = P - l
        other_wall = walls * (c4 + c5)
    print(wall_good + other_wall)
    file.close()
  
