with open('input.txt', mode='r') as file:
    data = file.readlines()
    in_end = int(data[-1])
    del data[0]
    del data[-1]
    x, other = 1, 0
    for i in data:
        line = i.split()
        operation = line[0]
        if 'x' in line[1]:
            x = eval(f'{x} + {operation} 1')
        else:
            num = int(line[1])
            other = eval(f'{other} {i}')
            x = eval(f'{x} {i}') if operation in '*/' else x
    print(int((in_end - other) / x))
