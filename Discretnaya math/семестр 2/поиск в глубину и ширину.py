# поиск в глубину
def find_connectivity(dct, vertex_start, black=None):
    if black is None:
        black = set()
    black.add(vertex_start)
    for i in set(dct[vertex_start]) - black:
        find_connectivity(dct, i, black)
    return black


# поиск в ширину
def find_conn2(visit, dct, edge):
    ans = ''
    visit.append(edge)
    que.append(edge)
    while que:
        i = que.pop(0)
        ans += i + " "
        for adjacent in dct[i]:
            if adjacent not in visit:
                visit.append(adjacent)
                que.append(adjacent)
    return ans


vertexes = input().split()  # все вершины
edges = list(map(lambda x: x.split(':'), input().split()))  # ребра через пробел вида a:b b:c
dct = {}
for vert in vertexes:
    dct[vert] = []
    [dct[vert].extend(set(vert) ^ set(edge)) for edge in edges if vert in edge]
answer, used = [], set()

print("Поиск в глубину: ", end='')
for vert in vertexes:
    if vert in used:
        continue
    lst = sorted(find_connectivity(dct, vert))
    print(' '.join(lst) + ' | ', end='')
    [used.add(i) for i in lst]

used = set()
print()
print("Поиск в ширину: ", end='')
for vert in vertexes:
    que, visit = [], []
    if vert in used:
        continue
    bfs = find_conn2(visit, dct, vert).strip()
    print(bfs, end=' | ')
    [used.add(i) for i in bfs.split()]
