Dictionary<string, Dictionary<string, Dictionary<string, int>>> dct = new Dictionary<string, Dictionary<string, Dictionary<string, int>>>();
Queue<string[]> queue = new Queue<string[]>();
Console.WriteLine("Вводите номер с которого звонили, номер на который звонили, дата разговора, кол-во минут через пробел");
Console.WriteLine("Введите stop чтобы закончить ввод");
string[] input = Console.ReadLine().Split();
while (input[0] != "stop")
{
    queue.Enqueue(input);
    input = Console.ReadLine().Split();
}
int steps = queue.Count;
for (int i = 0; i < steps; i++)
{
    string[] number = queue.Dequeue();
    if (dct.ContainsKey(number[2]) && dct[number[2]].ContainsKey(number[0]) && dct[number[2]][number[0]].ContainsKey(number[1]))
    {
        dct[number[2]][number[0]][number[1]] += int.Parse(number[3]);
    }
    else if (dct.ContainsKey(number[2]) && dct[number[2]].ContainsKey(number[0]) && !dct[number[2]][number[0]].ContainsKey(number[1]))
    {
        dct[number[2]][number[0]][number[1]] = int.Parse(number[3]);
    }
    else if (dct.ContainsKey(number[2]) && !dct[number[2]].ContainsKey(number[0]))
    {
        dct[number[2]][number[0]] = new Dictionary<string, int>( new Dictionary<string, int> { { number[1], int.Parse(number[3]) } });
    }
    else
    {
        dct[number[2]] = new Dictionary<string, Dictionary<string, int>>() { { number[0], new Dictionary<string, int>(){ { number[1], int.Parse(number[3]) } } } };
    }

}
dct = dct.OrderBy(key => key.Key).ToDictionary(obj => obj.Key, obj => obj.Value);

foreach (string data in dct.Keys)
{
    Console.WriteLine("Дата " + data);
    foreach (string number1 in dct[data].Keys)
    {
        int value2 = dct[data][number1].Values.Max();
        Console.WriteLine($"\t с номера больше всего звонили {number1}, кому {dct[data][number1].FirstOrDefault(x => x.Value == value2).Key}");
    }
    
}
