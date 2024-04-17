using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace C_ 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader streamReader = new StreamReader("C:\\Users\\Ekaterina\\Desktop\\city.txt");
            List<City> cityList = new List<City>();
            string[] line = streamReader.ReadLine().Split();
            while (line != null)
            {
                cityList.Add(new City(line[0], line[1], int.Parse(line[2])));
                try { line = streamReader.ReadLine().Split(); }
                catch (Exception){ line = null; }
            }
            streamReader.Close();

            char letter = 'В';
            var Ncity = cityList.Where(x => x.Name_Town[0].Equals(letter));
            StreamWriter sw1 = new StreamWriter("C:\\Users\\Ekaterina\\Desktop\\c1.txt");
            foreach (var i in Ncity) { sw1.WriteLine(i.Print()); };
            sw1.Close();

            Console.Write("Введите страну: "); string country = Console.ReadLine();
            var Ccity = cityList.Where(x => x.Name_Country.Equals(country));
            StreamWriter sw2 = new StreamWriter("C:\\Users\\Ekaterina\\Desktop\\c2.txt");
            foreach (var i in Ccity) { sw2.WriteLine(i.Print()); };
            sw2.Close();

            int population = 5000000;
            var Pcity = cityList.Where(x => x.Population >= population);
            StreamWriter sw3 = new StreamWriter("C:\\Users\\Ekaterina\\Desktop\\c3.txt");
            foreach (var i in Pcity) { sw3.WriteLine(i.Print()); };
            sw3.Close();

        }
    }
    public struct City
    {
        public City(string name_Town, string name_Country, int population)
        {
            Name_Town = name_Town; Name_Country = name_Country; Population = population;
        }
        public string Name_Town; public string Name_Country; public int Population;
        public string Print() => $"{Name_Town} {Name_Country} {Population}";
    }
