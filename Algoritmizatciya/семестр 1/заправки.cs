using System;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine()); int ans = 1000;
            string[] c = Console.ReadLine().Split();
            int[] city = new int[c.Length];
            for (int i = 0; i < c.Length; i++) { city[i] = int.Parse(c[i]); }
            int k = int.Parse(Console.ReadLine());
            if (city.Max() < k) { Console.WriteLine("no way"); }
            int[] bools = new int[city.Sum() + 1];
            bools[0] = 1;
            for (int i = 1, y = 0, u = city[0]; i < city.Sum() - 1; i++)
            { if (i == u) { bools[i] = 1; u += city[++y]; } else { bools[i] = 0; }
            } bools[bools.Length - 1] = 1;
            int ir = 0; int right_city = city[0];
            for (int i = 1, left_city = 0; i < bools.Length; i++) {
                if ((bools[i] == 0) && (i - left_city >= k) && (right_city - i >= k))
                {
                    int a = i;
                    left_city = right_city;// right_city += city[ir++]; 
                    right_city += city[ir + 1 == city.Length ? 0 : ++ir];
                    int rast = 0;
                    for (int j = 0; j < city.Length; j++)
                    {
                        rast += city[j];
                        a += Math.Abs(rast - i); 
                    }
                    ans = Math.Min(ans, a);
                }
            }
            Console.WriteLine(ans);
        }
    }
}
