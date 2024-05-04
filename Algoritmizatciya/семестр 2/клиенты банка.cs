internal class Program
{
    static void Main(string[] args)
    {
        List<Client> clients = new List<Client>() { new Client("14", "Гавканько Х.Ф.", 358426, 800),
        new Client("01", "Валеров Г.Ю.", 10, 1000000), new Client("02", "Пивко Ш.О.", 4000, 30),
        new Client("03", "Фильнов Н.Р.", 5000000, 0), new Client("36", "Уценовка Я.З.", 654654, 564565),
        new Client("98", "Дадимка Н.К.", 21321, 64487879), new Client("50", "Яльф Щ.Б.", 78978, 999999),
        new Client("33", "Жовучший А.Э.", 63247, 765410), new Client("04", "Циркенко З.С.", 9, 0)};

        int negative = clients.Where(p => p.Gain - p.Expense < 0).Count();
        Console.WriteLine($"Количесво клиентов с отрицательным балансом: {negative}");

        var richiest_client = from client in clients
                              orderby client.Gain - client.Expense - client.Taxes descending
                              select client;
        Console.WriteLine("\nКлиент с самым большим балансом с учетом уплаты налогов: " + richiest_client.First().Print());

        var average_balance = clients.Where(c => c.Gain - c.Expense < 0).Average(c => c.Gain);
        Console.WriteLine("\nСредний доход с отрицательным балансом: " + Convert.ToString(average_balance));

        var sum_all_taxes = clients.Sum(c => c.Taxes);
        Console.WriteLine("\nСуммарная сумма налогов со всех клиентов: " + Convert.ToString(sum_all_taxes));
    }
}
public struct Client
{
    public Client(string account_number, string name, int gain, int expense)
    {
        Account_Number = account_number; Name = name; Gain = gain; Expense = expense; Taxes = Gain * 0.05;
    }
    public string Account_Number; public string Name; public int Gain; public int Expense;  public double Taxes;
    public string Print() => Name;
}
