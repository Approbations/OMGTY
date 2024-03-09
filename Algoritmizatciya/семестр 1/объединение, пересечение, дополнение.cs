using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] nums = new int[n][]; 
            for (int i = 0; i < n; i++)
            {string[] s = Console.ReadLine().Split();
                int[] sn = s.Select(x => int.Parse(x)).ToArray();
                nums[i] = sn;}
            int[] peresech = new int[0];
            int[] objed = new int[0];
            int[][] dopolnenie = new int[n * (n - 1) / 2][];
            int k = 0;
            foreach (int[] i in nums)
            {foreach (int j in i) {if (!objed.Contains(j)){Array.Resize(ref objed, objed.Length + 1); objed[k++] = j;}}}
            
            foreach (int i in objed) { Console.Write(i + " "); }
            Console.WriteLine();
            
            int[] ints = new int[0];
            k = 0;
            foreach (int[] i in nums) { foreach (int j in i) { Array.Resize(ref ints, ints.Length + 1); ints[k++] = j; } }
            k = 0;
            foreach (int i in ints) { if ((ints.Count(x => x == i) == n) & (!peresech.Contains(i))) { Array.Resize(ref peresech, peresech.Length + 1); peresech[k++] = i; } }

            foreach (int i in peresech ) { Console.Write(i + " "); }
            Console.WriteLine();
            int dop = 0;
            for (int i = 0;  i < nums.Length - 1; i++)
            {
                for (int y = i + 1; y < nums.Length; y++) {
                int[] num = new int[0];

                int[] obsh = new int[nums[i].Length + nums[y].Length];
                k = 0;
                for (int j = 0; j < nums[i].Length; j++)
                {
                    obsh[k++] = nums[i][j];
                }
                for (int j = 0; j < nums[y].Length; j++)
                {
                    obsh[k++] = nums[y][j];
                }
                k = 0;
                foreach (int j in obsh) { if (obsh.Count(x => x == j) == 1 ) { Array.Resize(ref num, num.Length + 1); num[k++] = j; } }
                dopolnenie[dop++] = num;
                }
            }
            foreach (int[] i in dopolnenie) { foreach (int j in i) { Console.Write(j + " "); } Console.WriteLine(); }
        }
    }
}
