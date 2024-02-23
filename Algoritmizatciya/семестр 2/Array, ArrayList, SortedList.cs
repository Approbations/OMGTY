using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Threading;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "The My Menu";
            MainMenu myMainMenu = new MainMenu();
            myMainMenu.Start();
        }
    }
    internal class MainMenu
    {
        string[] arr; ArrayList arr_list; SortedList sorted_list;
        public void Start()
        {
            RunMainMenu();
            Console.ReadLine();
        }
        private void RunMainMenu()
        {
            Console.WriteLine("Выход в главное меню"); Thread.Sleep(1000);
            string promt = "Main Menu"; 
            string[] options = { "Array", "ArrayList", "SortedList", "Exit" };
            Menu mainMenu = new Menu(promt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    GoToArray();
                    break;
                case 1:
                    GoToArrayList();
                    break;
                case 2:
                    GoSortedList();
                    break;
                case 3:
                    ExitGame();
                    break;
            }

        }
        private void ExitGame()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("GoodBye");
            Thread.Sleep(1000);
            Environment.Exit(0);
        }
        private void GoToArray()
        {
            Console.Clear();
            Console.WriteLine("Напишите элементы для массива через пробел: ");
            arr = Console.ReadLine().Split(' ');
            Console.WriteLine("Выход в меню для коллекции Array"); Thread.Sleep(1000);
            RunArray();
        }
        private void RunArray()
        {
            string promt = "Array: "; foreach (string s in arr) { promt += s + " "; }
            string[] options = { "Count", "BinarySearch", "Copy", "Find", "FindLast", "IndexOf", "Reverse", "Resize", "Sort", "Exit to main menu"};
            Menu array_menu = new Menu(promt, options);
            int selectedIndex = array_menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine($"\nArray.Count: {arr.Count()}"); Thread.Sleep(1500); RunArray();
                    break;
                case 1:
                    Console.Write("\nКакой элемент в массиве нужно найти: "); string elem = Console.ReadLine();
                    Console.WriteLine($"Array.BinarySearch: {Array.BinarySearch(arr, elem)}"); Thread.Sleep(1500);
                    RunArray();
                    break;
                case 2:
                    Console.Write("\nВведите значения второго массива через пробел: "); string[] arr2 = Console.ReadLine().Split(' ');
                    Console.Write("Введите числа через пробел " +
                        "\n1. С какого индекса начинать копирование элементов  во второй массив" +
                        "\n2. С какого индекса начинать сохранение во втором массиве" +
                        "\n3. Сколько элементов скопировать с первого массива: "); 
                    int[] ind = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
                    Array.Resize(ref arr2, arr2.Length + ind[2]);
                    Array.Copy(arr, ind[0], arr2, ind[1], ind[2]); Console.Write("Получившийся массив: ");
                    foreach (string s in arr2) Console.Write(s + " "); Thread.Sleep(1000); RunArray();
                    break;
                case 3:
                    Console.Write("\nВведите наличие какого элемента обязательно в элементе массива (найдется первое вхождение): "); string need = Console.ReadLine();
                    Console.WriteLine($"Array.Find: {Array.Find(arr, i => i.Contains(need))}"); Thread.Sleep(1000); RunArray();
                    break;
                case 4:
                    Console.Write("\nВведите наличие какого элемента обязательно в элементе массива (найдется последнее вхождение): "); string need_last = Console.ReadLine();
                    Console.WriteLine($"Array.FindLast: {Array.FindLast(arr, i => i.Contains(need_last))}"); Thread.Sleep(1000); RunArray();
                    break;
                case 5:
                    Console.Write("\nВведите индекс какого элемента нужно найти: "); string ind_find = Console.ReadLine();
                    Console.WriteLine($"Array.IndexOf: {Array.IndexOf(arr, ind_find)}"); Thread.Sleep(1000); RunArray();
                    break;
                case 6:
                    arr.Reverse();
                    Console.Write("\nПеревернутый массив: "); foreach (string s in arr) { Console.Write(s + " "); } Thread.Sleep(1000); RunArray();
                    break;
                case 7:
                    Console.WriteLine("Введите какого размера должен стать массив: "); int new_size = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Старый размер массива: {arr.Length}"); Array.Resize<string>(ref arr, new_size);
                    Console.WriteLine($"Новый размер массива: {arr.Length}"); Thread.Sleep(1000); RunArray();
                    break;
                case 8:
                    Array.Sort(arr);
                    Console.Write("\nОтсортированный массив: "); foreach (string s in arr) { Console.Write(s + " "); } Thread.Sleep(1500); RunArray();
                    break;
                case 9:
                    RunMainMenu();
                    break;
            }
        }
        private void GoToArrayList()
        {
            Console.Clear();
            arr_list = new ArrayList();
            Console.WriteLine("Выход в меню для коллекции ArrayList"); Thread.Sleep(1000);
            RunArrayList();
        }
        private void RunArrayList()
        {
            string promt = "ArrayList: "; foreach (string s in arr_list) { promt += s + " "; }
            string[] options = {"Add", "Count", "BinarySearch", "CopyTo", "IndexOf", "Insert", "Reverse", "Sort", "Exit to main menu" };
            Menu array_list_menu = new Menu(promt, options);
            int selectedIndex = array_list_menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nВведите то, что хотите добавить: "); string input = Console.ReadLine();
                    arr_list.Add(input); Console.Write("ArrayList: "); foreach (string s in arr_list) {  Console.Write(s + " "); }
                    Thread.Sleep(1000); RunArrayList();
                    break;
                case 1:
                    Console.WriteLine($"\nArrayList.Count: {arr_list.Count}"); Thread.Sleep(1000); RunArrayList();
                    break;
                case 2:
                    Console.WriteLine("\nВведите то, что хотите найти: "); string find = Console.ReadLine();
                    Console.WriteLine($"ArrayList.BinarySearch: {arr_list.BinarySearch(find)}");
                    Thread.Sleep(1000); RunArrayList();
                    break;
                case 3:
                    Console.Write("\nВведите значения второго массива через пробел: "); string[] arr2 = Console.ReadLine().Split(' ');
                    Console.Write("Введите числа через пробел " +
                        "\n1. С какого индекса начинать копирование элементов  во второй массив" +
                        "\n2. С какого индекса начинать сохранение во втором массиве" +
                        "\n3. Сколько элементов скопировать с первого массива: ");
                    int[] ind = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
                    Array.Resize(ref arr2, arr2.Length + ind[2]);
                    arr_list.CopyTo(ind[0], arr2, ind[1], ind[2]); Console.Write("Получившийся массив: ");
                    foreach (string s in arr2) Console.Write(s + " "); Thread.Sleep(1000); RunArrayList();
                    break;
                case 4:
                    Console.Write("\nВведите то, чей индекс хотите найти: "); string find_ind = Console.ReadLine();
                    Console.WriteLine($"ArrayList.IndexOf: {arr_list.IndexOf(find_ind)}"); Thread.Sleep(1000); RunArrayList(); 
                    break;
                case 5:
                    Console.Write("\nВведите индекс и то, что хотите вставить, через пробел: "); string[] ind_elem = Console.ReadLine().Split(new char[] {' '}, 2);
                    arr_list.Insert(int.Parse(ind_elem[0]), ind_elem[1]); Console.Write("ArrayList с новым элементом: "); 
                    foreach (string s in arr_list) Console.Write(s + " "); Thread.Sleep(1000); RunArrayList();
                    break;
                case 6:
                    arr_list.Reverse(); Console.Write("\nArrayList.Reverse: "); foreach (string s in arr_list) {  Console.Write(s + " "); }
                    Thread.Sleep(1000); RunArrayList();
                    break;
                case 7:
                    arr_list.Sort(); Console.Write("\nArrayList.Sort: "); foreach (string s in arr_list) { Console.Write(s + " "); }
                    Thread.Sleep(1000); RunArrayList();
                    break;
                case 8:
                    RunMainMenu();
                    break;
            }
        }
        private void GoSortedList()
        {
            Console.Clear();
            sorted_list = new SortedList();
            Console.WriteLine("SortedList");
            RunSortedList();
        }
        private void RunSortedList()
        {
            string promt = "SortedList: "; for (int i = 0; i < sorted_list.Count; i++) {promt += $"[{sorted_list.GetKey(i)}:{sorted_list.GetByIndex(i)}], ";}
            string[] options = { "Add", "IndexOfKey", "IndexOfValue", "Получение ключа по значению", "Получение значения по ключу", "Exit to main menu" };
            Menu array_list_menu = new Menu(promt, options);
            int selectedIndex = array_list_menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Console.Write("\nВведите то, что хотите добавить, ключ и значение через пробел: "); string[] input = Console.ReadLine().Split(new char[] { ' ' }, 2);
                    sorted_list.Add(input[0], input[1]); Console.Write("SortedList: ");
                    for (int i = 0; i < sorted_list.Count; i++){Console.Write("[{0}:{1}], ", sorted_list.GetKey(i), sorted_list.GetByIndex(i));}
                    Thread.Sleep(1000); RunSortedList();
                    break;
                case 1:
                    Console.Write("\nВведите ключ индекс которого хотите найти: "); string find_key = Console.ReadLine();
                    Console.WriteLine($"SortedList.IndexOfKey: {sorted_list.IndexOfKey(find_key)}");
                    Thread.Sleep(1000); RunSortedList();
                    break;
                case 2:
                    Console.Write("\nВведите значение индекс которого хотите найти: "); string find_value = Console.ReadLine();
                    Console.WriteLine($"SortedList.IndexOfValue: {sorted_list.IndexOfValue(find_value)}");
                    Thread.Sleep(1000); RunSortedList();
                    break;
                case 3:
                    Console.Write("\nВведите значение по которому нужно найти ключ: "); string find_key_for_val = Console.ReadLine();
                    var key_of_val = sorted_list.GetKey(sorted_list.IndexOfValue(find_key_for_val)); Console.WriteLine("SortedList: {0}", key_of_val);
                    Thread.Sleep(1000); RunSortedList();
                    break;
                case 4:
                    Console.Write("\nВведите ключ по которому необходимо найти значение: "); string key = Console.ReadLine(); Console.WriteLine($"SortedList[{key}] = {sorted_list[key]}");
                    Thread.Sleep(1000); RunSortedList();
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }
        }
    }
    class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Promt;

        public Menu(string promt, string[] options)
        {
            Promt = promt;
            Options = options;
            SelectedIndex = 0;
        }

        private void DisplayOptions()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(Promt + '\n');
            Console.ResetColor();

            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefixL;
                string prefixR;
                if (i == SelectedIndex)
                {
                    prefixL = ">>";
                    prefixR = "<<";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    prefixL = "  ";
                    prefixR = "  ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine($"  {prefixL}[ {currentOption} ]{prefixR}");
            }
            Console.ResetColor() ;
        }
        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                Console.Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;
                if (keyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if (SelectedIndex < 0)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if (SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
