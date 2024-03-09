import math
MaxN = int(input())
answer = MaxN
for z in range(2, math.ceil(math.log(MaxN, 2)) + 1):
    n = 2 ** z - 1
    delitel = MaxN // n
    answer += delitel
print(answer)
