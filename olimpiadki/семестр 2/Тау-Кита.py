def human_word(word: list) -> str:
    word_flag = 0 if len(word) % 2 == 0 else -1
    new_word = ''
    for _ in range(len(word)):
        new_word = word[word_flag] + new_word
        del word[word_flag]
        word_flag = 0 if word_flag == -1 else -1
    return new_word


line = input().split()
answer = ''
flag = 0 if len(line) % 2 == 0 else -1

for _ in range(len(line)):
    answer = human_word(list(line[flag])) + ' ' + answer
    del line[flag]
    flag = 0 if flag == -1 else -1
print(answer)
