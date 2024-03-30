using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace C_
{
    interface IOpertations
    {
        double Addition(double n1, double n2); double Substraction(double n1, double n2); double Multiplication(double n1, double n2); double Division(double n1, double n2);
        double Square_root(double n); double Sin(double n); double Cos(double n);
    }
    internal class Program: IOpertations
    {
        static void Main(string[] args)
        {
            Console.Title = "Math Operations";
            MainMenu mainMenu = new MainMenu();
            mainMenu.Start();
        }
    }
    internal class MainMenu: IOpertations
    {
        delegate double MathDelegate_for2(double n1, double n2);
        delegate double MathDelegate_for1(double n);
        double IOpertations.Addition(double n1, double n2) { return n1 + n2; }
        double IOpertations.Substraction(double n1, double n2) { return n1 - n2; }
        double IOpertations.Multiplication(double n1, double n2) { return n1 * n2; }
        double IOpertations.Division(double n1, double n2) { return n1 / n2; }
        double IOpertations.Square_root(double n) { return Math.Sqrt(n); }
        double IOpertations.Sin(double n) { return Math.Sin(n); }
        double IOpertations.Cos(double n) { return Math.Cos(n); }
        
        public void Start()
        {
            RunMainMenu();
            Console.ReadLine();
        }
        private void RunMainMenu()
        {
            Console.WriteLine("Выход в главное меню"); Thread.Sleep(1000);
            string promt = "Main Menu";
            string[] options = { "Addition [+]", "Substraction [-]", "Multiplication [*]", "Division [/]", "Sqrt", "Sin", "Cos", "Exit" };
            IOpertations obj = new MainMenu();
            List<MathDelegate_for2> delegate1 = new List<MathDelegate_for2>() { obj.Addition, obj.Substraction, obj.Multiplication, obj.Division };
            List<MathDelegate_for1> delegate2 = new List<MathDelegate_for1>() { obj.Square_root, obj.Sin, obj.Cos };
            Menu mainMenu = new Menu(promt, options);
            int selectedIndex = mainMenu.Run();
            string[] arr;
            switch (selectedIndex)
            {
                case 0:
                    Console.Write("Введите 2 числа через пробел: "); arr = Console.ReadLine().Split(); 
                    Console.Write($"{arr[0]} + {arr[1]} = {delegate1[0](double.Parse(arr[0]), double.Parse(arr[1]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 1:
                    Console.Write("Введите 2 числа через пробел: "); arr = Console.ReadLine().Split();
                    Console.Write($"{arr[0]} - {arr[1]} = {delegate1[1](double.Parse(arr[0]), double.Parse(arr[1]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 2:
                    Console.Write("Введите 2 числа через пробел: "); arr = Console.ReadLine().Split();
                    Console.Write($"{arr[0]} * {arr[1]} = {delegate1[2](double.Parse(arr[0]), double.Parse(arr[1]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 3:
                    Console.Write("Введите 2 числа через пробел: "); arr = Console.ReadLine().Split();
                    if (double.Parse(arr[1]) == 0) { Console.WriteLine("Деление на ноль"); Thread.Sleep(1500); RunMainMenu(); }
                    Console.Write($"{arr[0]} / {arr[1]} = {delegate1[3](double.Parse(arr[0]), double.Parse(arr[1]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 4:
                    Console.Write("Введите число: "); arr = Console.ReadLine().Split();
                    if (double.Parse(arr[0]) < 0) { Console.WriteLine("Число меньше нуля"); Thread.Sleep(1500); RunMainMenu();}
                    Console.Write($"Sqrt({arr[0]}) = {delegate2[0](double.Parse(arr[0]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 5:
                    Console.Write("Введите число: "); arr = Console.ReadLine().Split();
                    Console.Write($"Sin({arr[0]}) = {delegate2[1](double.Parse(arr[0]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 6:
                    Console.Write("Введите число: "); arr = Console.ReadLine().Split();
                    Console.Write($"Cos({arr[0]}) = {delegate2[2](double.Parse(arr[0]))}");
                    Thread.Sleep(1500); RunMainMenu();
                    break;
                case 7:
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
