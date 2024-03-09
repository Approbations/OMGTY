import datetime
d1 = list(map(int, input().split('.')))
day1 = datetime.date(d1[-1], d1[1], d1[0])
d2 = list(map(int, input().split('.')))
first = int(input())
day2 = datetime.date(d2[-1], d2[1], d2[0])
delta = day2 - day1
last = first + delta.days
summ = (first + last) / 2 * (delta.days + 1)
print(summ)
