Console.Write("Введите значения для множества 1 через пробел: "); HashSet<string> set1 = new HashSet<string>(Console.ReadLine().Split()); 
Console.Write("Введите значения для множества 2 через пробел: "); HashSet<string> set2 = new HashSet<string>(Console.ReadLine().Split());
Console.Write("Введите значения для множества 3 через пробел: "); HashSet<string> set3 = new HashSet<string>(Console.ReadLine().Split());

HashSet<string> copy_set1 = set1.ToArray<string>().ToHashSet();
HashSet<string> copy_set2 = set2.ToArray<string>().ToHashSet();
HashSet<string> copy_set3 = set3.ToArray<string>().ToHashSet();

Console.Write("Пересечение множеств 1 и 2: "); copy_set1.IntersectWith(set2); foreach (string s in copy_set1) { Console.Write(s + " "); } copy_set1 = set1.ToArray<string>().ToHashSet();
Console.Write("\nПересечение множеств 1 и 3: "); copy_set1.IntersectWith(set3); foreach (string s in copy_set1) { Console.Write(s + " "); } copy_set1 = set1.ToArray<string>().ToHashSet();
Console.Write("\nПересечение множеств 2 и 3: "); copy_set2.IntersectWith(set3); foreach(string s in copy_set2) { Console.Write(s + " "); } copy_set2 = set2.ToArray<string>().ToHashSet();
           
Console.Write("\n\nОбъединение множеств 1 и 2: "); copy_set1.UnionWith(set2); foreach (string s in copy_set1) { Console.Write(s + " "); }
Console.Write("\nОбъединение множеств 1 и 3: "); copy_set2.UnionWith(set3); foreach (string s in copy_set2) { Console.Write(s + " "); }
Console.Write("\nОбъединение множеств 2 и 3: "); copy_set3.UnionWith(set2); foreach (string s in copy_set3) { Console.Write(s + " "); }

Console.Write("\n\nДополнение множества 3 до объединения 1 и 2: "); set3.ExceptWith(copy_set1); foreach (string s in set3) { Console.Write(s + " "); }
Console.Write("\nДополнение множества 2 до объединения 1 и 3: "); set2.ExceptWith(copy_set2); foreach (string s in set2) { Console.Write(s + " "); }
Console.Write("\nДополнение множества 1 до объединения 2 и 3: "); set1.ExceptWith(copy_set3); foreach (string s in set1) { Console.Write(s + " "); }
