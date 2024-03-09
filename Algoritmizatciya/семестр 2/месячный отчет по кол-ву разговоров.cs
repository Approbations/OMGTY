Queue<string[]> queue = new Queue<string[]>(); Dictionary<string, int> dct = new Dictionary<string, int>();
Hashtable hashtable = new Hashtable();
Console.WriteLine("Вводите номер, дата начала разговора, время начала разговора, кол-во минут через пробел");
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
    if (dct.ContainsKey(number[0])) { 
        dct[number[0]] += int.Parse(number[3]);
         int sum = int.Parse(hashtable[number[0]].ToString());
         hashtable.Remove(number[0]); hashtable.Add(number[0], int.Parse(number[3]) + sum);
    }
    else { 
        dct[number[0]] = int.Parse(number[3]);
        hashtable.Add(number[0], int.Parse(number[3]));
    }
}
foreach (string number in dct.Keys)
{
    Console.WriteLine($"Dictonary| {number}: {dct[number]}");
    Console.WriteLine($"Hashtable| {number}: {hashtable[number]}");
}
