import copy
# 12 clear tests
datain = open(r"C:\Users\Ekaterina\Downloads\Формы для отливки\Формы для отливки\input1.txt", mode='r')
data = open(r"C:\Users\Ekaterina\Downloads\Формы для отливки\Формы для отливки\output1.txt", mode='r')
a = data.readline().split()
count = True


def matching_form_with_detail(n_det: int, forma: list, front_or_back=1) -> list:
    global details
    lst = [False, False, False, False]
    lst[0] = forma[0] == details[n_det][0]
    lst[2] = forma[2] == details[n_det][2]
    if front_or_back:
        lst[1] = forma[1] == details[n_det][1]
    else:
        lst[3] = forma[3] == details[n_det][1]
    return lst


def cyclic_shift(lst: list, step: int) -> list:
    return lst[-step:] + lst[:-step]


def check(n_1, n_2, d10, d11, d20, d21) -> bool:
    ans_bool = False
    ans_bool += ([h or d21[c] for c, h in enumerate(d10)].count(True) == 4) and (
        d10.count(True) == 3) and (d21.count(True) == 3) or \
        ([h or d20[c] for c, h in enumerate(d11)].count(True) == 4) and (
        d11.count(True) == 3) and (d20.count(True) == 3)
    if not ((n_1 >= 4) and (n_2 >= 4) or (n_1 < 4) and (n_2 < 4)):
        ans_bool += ([h or det21_c[c] for c, h in enumerate(det11_c)].count(True) == 4) and (
                det11_c.count(True) == 3) and (det21_c.count(True) == 3) or \
                    ([h or det20_c[c] for c, h in enumerate(det10_c)].count(True) == 4) and (
                            det10_c.count(True) == 3) and (det20_c.count(True) == 3)
    return ans_bool


uses = set()
N = int(datain.readline())
forms = []
for _ in range(N):
    form = datain.readline().split()
    forms.append([[form[i], form[i + 1], form[i + 2], form[i + 3], form[i + 4]] for i in range(0, 20, 5)])
details = []
for _ in range(2 * N):
    det = datain.readline().split()
    details.append([[det[i], det[i + 1], det[i + 2], det[i + 3], det[i + 4]] for i in range(0, 15, 5)])
datain.close()

for n, form in enumerate(forms):
    flag = False
    form_straight = copy.deepcopy(form)
    form_str_rotate90 = [form[3], form[0], form[1], form[2]]
    form_str_rotate180 = [form[2], form[3], form[0], form[1]]
    form_str_rotate270 = [form[1], form[2], form[3], form[0]]

    form_reverse = list(map(lambda x: x[::-1], copy.deepcopy(form)))
    form_rev_rotate90 = list(map(lambda x: x[::-1], copy.deepcopy(form_str_rotate90)))
    form_rev_rotate180 = list(map(lambda x: x[::-1], copy.deepcopy(form_str_rotate180)))
    form_rev_rotate270 = list(map(lambda x: x[::-1], copy.deepcopy(form_str_rotate270)))
    list_of_form = [form_straight, form_str_rotate90, form_str_rotate180, form_str_rotate270,
                    form_reverse, form_rev_rotate90, form_rev_rotate180, form_rev_rotate270]
    answer = []
    answer2 = []
    
    for n_det1 in range(2 * N):
        list_of_det1_1 = [matching_form_with_detail(n_det1, i) for i in list_of_form]
        list_of_det1_0 = [matching_form_with_detail(n_det1, i, 0) for i in list_of_form]
        if [(i.count(True) == 3) or (list_of_det1_1[n].count(True) == 3) for n, i in enumerate(list_of_det1_0)].count(True) == 0:
            continue

        for n_det2 in range(n_det1 + 1, N * 2):
            if (n_det2 + 1) in uses:
                continue
            list_of_det2_0 = [matching_form_with_detail(n_det2, i, 0) for i in list_of_form]
            list_of_det2_1 = [matching_form_with_detail(n_det2, i) for i in list_of_form]
            if [(i.count(True) == 3) or (list_of_det2_1[n].count(True) == 3) for n, i in enumerate(list_of_det2_0)].count(True) == 0:
                continue
            checking = False
            checking2 = False
            for n1, i in enumerate(list_of_det1_0):

                det10_c = i
                det11_c = list_of_det1_1[n1]
                for n2, j in enumerate(list_of_det2_0):
                    if abs(n2 - n1) % 2 != 0:
                        continue
                    det20_c = cyclic_shift(j, abs(n1 - n2) if abs(n1 - n2) <= 3 else abs(n1 - n2) % 4)
                    det21_c = cyclic_shift(list_of_det2_1[n2], abs(n1 - n2) if abs(n1 - n2) <= 3 else abs(n1 - n2) % 4)
                    checking += check(n1, n2, det10_c, det11_c, det20_c, det21_c)
                    checking2 += check(0, 8, det10_c, det11_c, det20_c, det21_c)
            if checking:
                answer.append(sorted([n_det1 + 1, n_det2 + 1]))
                flag = True
                break
            if checking2:
                answer2.append(sorted([n_det1 + 1, n_det2 + 1]))

    if (len(answer) != 1) and (len(answer2) == 1):
        try:
            uses.add(answer2[0][0])
            uses.add(answer2[0][1])
            an = list(map(str, answer2[0]))
            count *= an == a
            if an != a:
                print(n, answer, answer2, a, 1)
        except IndexError:
            print(n, 0)
    else:
        try:
            if len(answer) == 2:
                uses.add(answer[1][0])
                uses.add(answer[1][1])
                an = list(map(str, answer[1]))
            else:
                uses.add(answer[0][0])
                uses.add(answer[0][1])
                an = list(map(str, answer[0]))
            count *= an == a
            if an != a:
                print(n, answer, answer2, a)
        except IndexError:
            print(n, 1)
    print(answer, answer2)
    a = data.readline().split()
print(count)

data.close()
