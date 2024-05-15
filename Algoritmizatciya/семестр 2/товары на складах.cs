internal class Program
{
    static void Main(string[] args)
    {
        Product[] products = { new Product("01", "Сыр", "Молочная продукция", 1000, 200, "1"),
        new Product("01", "Сыр", "Молочная продукция", 450, 200, "2"), new Product("02", "Грудинка", "Мясо", 200, 500, "1"),
        new Product("03", "Бедрышки", "Мясо", 1400, 700, "3"), new Product("04", "Ириски", "Конфеты", 20000, 100, "2"),
        new Product("05", "Барбарис", "Конфеты", 2000, 50, "3")};
        var storages = (from i in products select i.Storage).Distinct(); var categories = (from i in products select i.Category).Distinct();
        Console.WriteLine("Объем товаров в денежном эквиваленте по каждому скаладу");
        var products_costs = from store in storages
                             let sum = products.Where(s => s.Storage == store).Select(s => s.Amount * s.Price).Sum()
                             select new { store, sum };
        foreach( var product in products_costs ) { Console.WriteLine(product); }
        Console.WriteLine("\nМаксимальная цена товара по каждой категории");
        var max_in_category = from category in categories
                              let max = products.Where(s => s.Category == category).Select(s => s.Price).Max()
                              select new { category, max };
        foreach( var product in max_in_category ) { Console.WriteLine(product); }

        var average_value = from category in categories
                      let average = products.Where(s => s.Category == category).Select(s => s.Price).Average()
                      select new { category, average };
        Console.WriteLine("\nСредняя цена товаров по каждой категории");
        foreach (var product in average_value) { Console.WriteLine(product); }
        Console.WriteLine("\nСамый дешевый товар по каждому скалду");
        var cheapest_product = from store in storages
                               let minimum = products.Where(s => s.Storage == store).Select(s => s.Price).Min()
                               select new { store, minimum};
        foreach (var product in cheapest_product) { Console.WriteLine(product); }
    }
}
public struct Product
{
    public Product(string article, string name_product, string category, int amount, int price, string storage)
    {
        Article = article; Name = name_product; Category = category; Amount = amount; Price = price; Storage = storage;
    }
    public string Article; public string Name; public string Category; public int Amount;  public int Price;public string Storage;
}
