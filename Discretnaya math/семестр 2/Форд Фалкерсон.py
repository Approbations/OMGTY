class Edges:
    def __init__(self, vertex, capacity) -> None:
        self.vertex = vertex
        self.flow = 0
        self.capacity = capacity

    def get_valid_capacity(self) -> int:
        return self.capacity - self.flow


def new_edge(vertex, vertex_where, capacity) -> None:
    graph[vertex].append(len(edges))
    edges.append(Edges(vertex_where, capacity))
    graph[vertex_where].append(len(edges))
    edges.append(Edges(vertex, 0))


def ford_fulkerson(vertex, min_capacity) -> int:
    if vertex == finish:
        return min_capacity
    already_used[vertex] = t
    for i in graph[vertex]:
        if (edges[i].get_valid_capacity() == 0) or (already_used[edges[i].vertex] == t):
            continue
        x = ford_fulkerson(edges[i].vertex, min(min_capacity, edges[i].get_valid_capacity()))
        if x:
            edges[i].flow += x
            edges[i ^ 1].flow -= x
            return x
    return 0

# пример с пары
to_input = [[0, 1, 20], [0, 2, 30], [0, 3, 10], [1, 2, 40], [1, 4, 30], [2, 3, 10], [2, 4, 20], [3, 4, 20]]
start, finish = 0, 4
graph = [[] for _ in range(5)]
edges, already_used = [], [0] * 5
t = 1
for i in to_input:
    new_edge(*i)
while ford_fulkerson(start, float('inf')):
    t += 1

res = sum(edges[ind].flow for ind in graph[start])
print(res)
