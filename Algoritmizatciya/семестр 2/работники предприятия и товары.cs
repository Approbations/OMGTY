internal class Program
{
    static void Main(string[] args)
    {
        Worker[] workers = { new Worker("01", "Шошучкидзе Й.Р.", "Постельное белье", 10000, 5, 100), new Worker("02", "Фунька Ч.А.", "Металлолом", 12000, 100, 1),
        new Worker("03", "Соспунчик Р.Ю.", "Постельное белье", 8000, 10, 1000), new Worker("04", "Гидренко Х.В.", "Мебель", 2000, 6, 450),
        new Worker("05", "Уйлынка В.Ж.", "Мебель", 100000, 1, 9000), new Worker("06", "Тибринщико Е.Г.", "Металлолом", 100, 10000, 1)};

        int lower_that_did = (from worker in workers
                             where worker.Calary < worker.Price * worker.Amount
                             select worker).Count();
        Console.WriteLine($"Количество работником которым недоплачивают: {lower_that_did}\n");

        var products_in_category = from category in (from i in workers select i.Category).Distinct()
                                   let produced = workers.Where(s => s.Category == category).Select(s => s.Amount).Sum()
                                   select new { category, produced };
        Console.WriteLine("Средняя количество произведенных товаров в категории");
        foreach (var p in products_in_category) { Console.WriteLine(p); }

        var sum_in_category = from category in (from i in workers select i.Category).Distinct()
                                   let produced = workers.Where(s => s.Category == category).Select(s => s.Amount * s.Price).Sum()
                                   select new { category, produced };
        Console.WriteLine("\nСуммарный объем произведенной продукции");
        foreach (var p in sum_in_category) { Console.WriteLine(p); }

        var workers_higher_50 = (from worker in workers
                                    where worker.Price * worker.Amount < worker.Calary * 0.5
                                    select worker).Count();
        Console.WriteLine($"\nКол-во работников получающих больше 50% чем они сделали: {workers_higher_50}"); 
    }
}
public struct Worker
{
    public Worker(string service_number, string name, string category, int calary, int amount, int price)
    {
        Service_number = service_number; Name = name; Category = category; Calary = calary; Amount = amount; Price = price;
    }
    public string Service_number; public string Name; public string Category; public int Calary; public int Amount;  public int Price;
}
