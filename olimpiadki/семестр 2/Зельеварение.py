def name_ingr(potion):
    potion[0] = dct[potion[0]]
    potion[1] = potion[1].split()
    name = ""
    for let in potion[1]:
        if let.isdigit():
            name += all_ingredients[int(let) - 1]
        else:
            name += let
    all_ingredients.append(potion[0][0] + name + potion[0][1])


with open("input.txt", "r") as file:
    data = file.readlines()
    all_ingredients = []
    dct = {"MIX": ["MX", "XM"], "WATER": ["WT", "TW"], "DUST": ["DT", "TD"], "FIRE": ["FR", "RF"]}
    [name_ingr(line.split(maxsplit=1)) for line in data]
    print(all_ingredients[-1])
