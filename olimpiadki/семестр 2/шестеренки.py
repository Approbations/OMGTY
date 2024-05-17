class Gears: # не проходят последний тест
    def __init__(self, number, points, speed, rotation):
        self.number, self.points, self.speed, self.rotation, self.conns = number, points, speed, rotation, []

    def __str__(self) -> str:
        return f"{self.rotation}\n{'{:.3f}'.format(self.speed)}"

    def conn(self, what):
        self.conns.append(what)

    def reconnect(self, data):
        for i in self.conns:
            if data[i].rotation == 0:
                data[i].rotation = -self.rotation
                data[i].speed = self.speed * self.points / data[i].points
            elif data[i].rotation == self.rotation:
                return False
            elif abs(data[i].speed * data[i].points - self.speed * self.points) > (1 / 2.71 ** 5):
                return False
        return True


N, M = map(int, input().split())
gears = [Gears(0, 0, 0, 0) for _ in range(N)]
for i in range(N):
    gear = list(map(int, input().split()))
    gears[gear[0] - 1] = Gears(gear[0], gear[1], 0, 0)
data = [sorted(map(int, input().split())) for _ in range(M)]
error = 1
start, end = map(int, input().split())
gears[0].rotation, gears[0].speed = int(input()), 1

for i in data:
    gears[i[0] - 1].conn(i[1] - 1)
    gears[i[1] - 1].conn(i[0] - 1)

for i in gears:
    if not i.reconnect(gears):
        error = -1
        break

print(error)
if error == 1:
    print(gears[end - 1])
