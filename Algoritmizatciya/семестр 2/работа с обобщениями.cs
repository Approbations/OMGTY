using System;
using System.Linq;
using System.Threading;

namespace C_ 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Работа с обобщениями";
            MainMenu mainMenu = new MainMenu();
            mainMenu.Start();
        }
    }
    public class Operations<T>
    {
        public T number1;
        public T number2;
        public Operations(T n1, T n2)
        {
            number1 = n1;
            number2 = n2;
        }

        public void Plus()
        {
            dynamic result = Convert.ChangeType((dynamic)number1 + (dynamic)number2, typeof(T));
            Console.WriteLine(result);
        }
        public void Division()
        {
            try {
            dynamic result = Convert.ChangeType((dynamic)number1 / (dynamic)number2, typeof(T));
            Console.WriteLine(result); }
            catch (Exception) { Console.WriteLine("Ошибка"); }
        }
        public void Minus()
        {
            dynamic result = Convert.ChangeType((dynamic)number1 - (dynamic)number2, typeof(T));
            Console.WriteLine(result);
        }
        public void Multiplication()
        {
            dynamic result = Convert.ChangeType((dynamic)number1 * (dynamic)number2, typeof(T));
            Console.WriteLine(result);
        }
    }
    internal class MainMenu
    {
        int[] arrInts; double[] arrDouble; Operations<int> numbers_int; Operations<double> numbers_double;
        public void Start()
        {
            RunMainMenu();
            Console.ReadLine();
        }
        private void RunMainMenu()
        {
            Console.WriteLine("Выход в главное меню"); Thread.Sleep(1000);
            string promt = "Main Menu";
            string[] options = { "Работа с целочисленным типом", "Работа с вещественным типом", "Exit" };
            Menu mainMenu = new Menu(promt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    GoToInt();
                    break;
                case 1:
                    GoToDouble();
                    break;
                case 2:
                    ExitGame();
                    break;
            }
        }
        private void GoToInt()
        {
            Console.Clear();
            Console.WriteLine("Напишите числа целого типа через пробел: ");
            arrInts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
            numbers_int = new Operations<int>(arrInts[0], arrInts[1]);
            Console.WriteLine("Выход в меню"); Thread.Sleep(1000);
            RunInt();
        }
        private void RunInt()
        {
            string promt = $"Int Числа: {arrInts[0]}, {arrInts[1]}";
            string[] options = { "Сложение [+]", "Вычитание [-]", "Умножение [*]", "Деление [/]", "Ввести другие числа", "Exit"};
            Menu Int_menu = new Menu(promt, options);
            int selectedIndex = Int_menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    numbers_int.Plus(); Thread.Sleep(1000); RunInt();
                    break;
                case 1:
                    numbers_int.Minus(); Thread.Sleep(1000); RunInt();
                    break;
                case 2:
                    numbers_int.Multiplication(); Thread.Sleep(1000); RunInt();
                    break;
                case 3:
                    numbers_int.Division(); Thread.Sleep(1000); RunInt();
                    break;
                case 4:
                    arrInts = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i)).ToArray<int>();
                    numbers_int = new Operations<int>(arrInts[0], arrInts[1]);
                    Thread.Sleep(1000); RunInt();
                    break;
                case 5:
                    RunMainMenu();
                    break;
            }
        }
        private void GoToDouble()
        {
            Console.Clear();
            Console.WriteLine("Напишите числа вещественного типа через пробел: ");
            arrDouble = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => double.Parse(i)).ToArray<double>();
            numbers_double = new Operations<double>(arrDouble[0], arrDouble[1]);
            Console.WriteLine("Выход в меню"); Thread.Sleep(1000);
            RunDouble();
        }
        private void RunDouble()
        {
            string promt = $"Double Числа: {arrDouble[0]}, {arrDouble[1]}";
            string[] options = { "Сложение [+]", "Вычитание [-]", "Умножение [*]", "Деление [/]", "Ввести другие числа", "Exit" };
            Menu Double_menu = new Menu(promt, options);
            int selectedIndex = Double_menu.Run();
            switch (selectedIndex)
            {
                case 0:
                    numbers_double.Plus(); Thread.Sleep(1000); RunDouble();
                    break;
                case 1:
                    numbers_double.Minus(); Thread.Sleep(1000); RunDouble();
                    break;
                case 2:
                    numbers_double.Multiplication(); Thread.Sleep(1000); RunDouble();
                    break;
                case 3:
                    numbers_double.Division(); Thread.Sleep(1000); RunDouble();
                    break;
                case 4:
                    arrDouble = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => double.Parse(i)).ToArray<double>();
                    numbers_double = new Operations<double>(arrDouble[0], arrDouble[1]);
                    Thread.Sleep(1000); RunDouble();
                    break;
                case 5:
                    RunMainMenu();
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
            Console.ResetColor();
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
