using System;
using System.Collections.Generic;
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
        List<Auditorium> Auds = new List<Auditorium>();
        public void Start()
        {
            RunMainMenu();
            Console.ReadLine();
        }
        private void RunMainMenu()
        {
            Console.WriteLine("Выход в главное меню"); Thread.Sleep(1000);
            string promt = "Main Menu";
            string[] options = { "Создание базы данных", "Добавление аудитории в базу данных", "Изменение данных аудитории по заданному номеру", 
                "Выборка аудитории с кол-вом посадочных мест больше равным данного", "Выборка аудитории с проектором", 
                "Выборка аудиторй с пк и заданным кол-вом посадочных мест", "Выборка аудиторий по номеру этажа", "Вывод всех данных по аудиториям", "Exit" };
            Menu mainMenu = new Menu(promt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    CreateNewDB();
                    break;
                case 1:
                    AddNewAud();
                    break;
                case 2:
                    ChangeData();
                    break;
                case 3:
                    SelectAudSeats();
                    break;
                case 4:
                    SelectAudProj();
                    break;
                case 5:
                    SelectAudPC();
                    break;
                case 6:
                    SelectAudFloor();
                    break;
                case 7:
                    SelectAllData();
                    break;
                case 8:
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
        
        private void CreateNewDB()
        {
            Console.Clear();
            Console.WriteLine("1");
            Console.WriteLine("Вы точно хотите создать новую базу данных? Текущая база будет удалена. \n0 - нет, 1 - да создать новую бд");
            string check = CheckP(Console.ReadLine());
            switch (check)
            {
                case "0":
                    RunMainMenu();
                    break;
                case "1":
                    Console.WriteLine("Новая база данных создана");
                    Auds = new List<Auditorium>();
                    RunMainMenu();
                    break;
                default:
                    Console.WriteLine("Неверный формат");
                    break;
            }
        }
        private void AddNewAud()
        {
            Console.Clear();
            Console.WriteLine("Введите номер аудитории, состоящий из трех цифр, где первая цифра - это номер этажа (от 1 до 9), а остальные две номер аудитории.");
            Auditorium Aud = null;
            string NumberAud = CheckAud(Console.ReadLine());
            while (true)
            {
                foreach (Auditorium auditorium in Auds)
                {
                    if (auditorium.sortByAud(auditorium, NumberAud) != null) { Aud = auditorium; }
                }
                if (Aud != null) { Console.WriteLine("Такая аудитория уже есть, введите другой номер"); NumberAud = CheckAud(Console.ReadLine()); Aud = null;}
                else { break; }
            }

            Console.WriteLine("Введите кол-во посадочных мест");
            int seats = CheckSeats(Console.ReadLine());

            Console.WriteLine("Введите 1, если проектор есть, иначе 0.");
            string haveproj = CheckP(Console.ReadLine());

            Console.WriteLine("Введите 1, если компьютеры есть, иначе 0.");
            string HavePC = CheckP(Console.ReadLine());
            Auds.Add(new Auditorium(NumberAud, seats, haveproj, HavePC));
            RunMainMenu();
        }
        private void ChangeData()
        {
            Console.Clear();
            Console.Write("Напишите номер аудитории в которой хотите изменить данные: "); string NumberAud = CheckAud(Console.ReadLine());
            Auditorium AudForChange = null;
            while (true)
            {
                foreach (Auditorium auditorium in Auds)
                {
                    if (auditorium.sortByAud(auditorium, NumberAud) != null) { AudForChange = auditorium; }
                }
                if (AudForChange == null) { Console.WriteLine("Такой аудитории нет, введите другой номер"); NumberAud = CheckAud(Console.ReadLine());}
                else { break; }
            }

            Console.Write("Напишите 0, если хотите изменить кол-во мест, 1 - наличие проектора, 2 - наличие пк: "); string change = Console.ReadLine();
            while (true) { 
            bool f = false;
            switch (change)
            {

                case "0":
                    Console.WriteLine("Введите кол-во посадочных мест");
                    int seats = CheckSeats(Console.ReadLine());
                    AudForChange.Seats = seats;
                    break;
                case "1":
                    Console.WriteLine("Введите 1, если проектор есть, иначе 0.");
                    string haveproj = CheckP(Console.ReadLine());
                    AudForChange.Projector = haveproj;
                    break;
                case "2":
                    Console.WriteLine("Введите 1, если компьютеры есть, иначе 0.");
                    string HavePC = CheckP(Console.ReadLine());
                    AudForChange.PC = HavePC;
                    break;
                default:
                    f = true;
                    Console.WriteLine("Неверный формат");
                    break;
            } if (!f) { break; } change = Console.ReadLine();
        }
            RunMainMenu();

        }
        private void SelectAudSeats()
        {
            Console.Clear();
            Console.Write("Введите от скольки посадочных мест должно быть в аудитории"); int seats = CheckSeats(Console.ReadLine());
            foreach (Auditorium aud in Auds)
            {
                if (aud.SortBySeats(aud, seats) != null)
                { Console.WriteLine(aud.GetInfo(aud.SortBySeats(aud, seats))); }
            }
            RunMainMenu();
        }
        private void SelectAudProj()
        {
            Console.Clear();
            Console.Write("Введите 0, если проектор не нужен, иначе 1: "); string proj = CheckP(Console.ReadLine());
            foreach (Auditorium auditorium in Auds)
            {
                if (auditorium.SortByProj(auditorium, proj) != null)
                Console.WriteLine(auditorium.GetInfo(auditorium.SortByProj(auditorium, proj)));
            }
            RunMainMenu();
        }
        private void SelectAudPC()
        {
            Console.Clear();
            Console.Write("Введите 0, если компьютеры не нужны, иначе 1: "); string pc = CheckP(Console.ReadLine());
            Console.Write("Введите сколько минимум должно быть мест в аудитории: "); int seats = CheckSeats(Console.ReadLine());
            foreach (Auditorium aud in Auds)
            {
                if ((aud.SortByPC(aud, pc) != null) && (aud.SortBySeats(aud, seats) != null))
                Console.WriteLine(aud.GetInfo(aud.SortBySeats(aud.SortByPC(aud, pc), seats)));
            }
            RunMainMenu();
        }
        private void SelectAudFloor()
        {
            Console.Clear();
            Console.Write("Введите необходимый номер этажа (от 1 до 9): "); string floor = Console.ReadLine();
            while (true)
            {
                if ((floor.Length == 1) && ('1' <= floor[0]) && (floor[0] <= '9') && char.IsDigit(floor[0]))
                {
                    break;
                }
                Console.Write("Неверный формат, попробуйтe ещё: ");
                floor = Console.ReadLine();
            }
            foreach (Auditorium a in Auds)
            {
                if (a.SortByFloor(a, floor) != null)
                Console.WriteLine(a.GetInfo(a.SortByFloor(a, floor)));
            }
            RunMainMenu();
        }
        private void SelectAllData()
        {
            Console.Clear();
            Console.WriteLine("Вывод всех аудиторий");
            foreach (Auditorium a in Auds)
            {
                Console.WriteLine(a.GetInfo(a));
            }
            Thread.Sleep(2000);
            RunMainMenu();

        }
        private int CheckSeats(string s)
        {
            while (true)
            {
                bool f = true;
                foreach (char i in s)
                {
                    if (!char.IsDigit(i)) { f = false; Console.WriteLine("Неверный тип данных"); break; }
                }
                if (f && (int.Parse(s) > 0))
                {
                    Console.WriteLine("Успешно"); break;
                }
                Console.Write("Повторите еще: ");
                s = Console.ReadLine();
            }
            return int.Parse(s);
        }
        private string CheckP(string proj)
        {
            while (true)
            {
                bool flag;
                switch (proj)
                {
                    case "0":
                        flag = true;
                        Console.WriteLine("Успешно");
                        break;
                    case "1":
                        flag = true;
                        Console.WriteLine("Успешно");
                        break;
                    default:
                        flag = false;
                        Console.Write("Неверный формат. Попробуйте ещё: ");
                        break;
                }
                if (flag) { break; }
                else { proj = Console.ReadLine(); }
            }
            return proj;
        }
        private string CheckAud(string aud)
        {
            while (true)
            {
                if (aud.Length != 3) { Console.WriteLine("Длина не равна 3"); }
                else if (char.IsDigit(aud[0]) && ('1' <= aud[0]) && (aud[0] <= '9') && char.IsDigit(aud[1]) && char.IsDigit(aud[2]))
                {
                    break;
                }
                else { Console.WriteLine("Неверный формат ввода данных"); }
                Console.Write("Повторите ещё: ");
                aud = Console.ReadLine();
            }
            return aud;
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


    class Auditorium
    {
        private String number_of_aud; private int seats; private String projector; private String pc;
        public Auditorium(String number_of_aud, int seats, String projector, String pc)
        {
            this.number_of_aud = number_of_aud;
            this.seats = seats;
            this.projector = projector;
            this.pc = pc;
        }
        public Auditorium sortByAud(Auditorium aud, string name)
        {
            if (aud.number_of_aud == name)
            {
                return aud;
            }
            return null;
        }
        public Auditorium SortBySeats(Auditorium aud, int more_seats)
        {
            if (aud.seats >= more_seats)
            {
                return aud;
            }
            return null;
        }
        public String GetInfo(Auditorium aud)
        {
            return $"{aud.number_of_aud}\t{aud.seats}\t{aud.projector}\t{aud.pc}";
        }
        public Auditorium SortByFloor(Auditorium aud, string floor)
        {
            if (aud.number_of_aud[0] == char.Parse(floor))
            {
                return aud;
            }
            return null;
        }
        public Auditorium SortByProj(Auditorium aud, string proj)
        {
            if (aud.Projector == proj)
            {
                return aud;
            }
            return null;
        }
        public Auditorium SortByPC(Auditorium aud, string PC)
        {
            if (aud.PC == PC)
            {
                return aud;
            }
            return null;
        }
        public int Seats
        {
            get { return seats; }
            set { this.seats = value; }
        }

        public String Projector
        {
            get { return this.projector; }
            set { this.projector = value; }
        }

        public String PC
        {
            get { return this.pc; }
            set { this.pc = value; }
        }
        public String Number_of_aud
        {
            get { return this.number_of_aud; }
            set { this.number_of_aud = value; }
        }
    }
}
