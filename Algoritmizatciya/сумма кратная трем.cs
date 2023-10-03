using System;

internal class Program
{
    static void Main(string[] args)
    {
        int all = int.Parse(Console.ReadLine()); 
        int min1, min2, answer, n1, n2, difference, ostat_ot_del;
        min1 = min2 = 10000; int m1, m2; m1 = min1; m2 = min2;
        answer = 0; 
        for (int i = 0; i < all; i++)
        {
            string[] line = Console.ReadLine().Split();
            n1 = int.Parse(line[0]); n2 = int.Parse(line[1]);
            answer += Math.Max(n1, n2);
            difference = Math.Abs(n1 - n2);
            ostat_ot_del = difference % 3;
            if (ostat_ot_del > 0)
            {
                m1 = min1; m2 = min2;
                for (int j = 1; j < 3; j++)
                {
                    int r0 = (ostat_ot_del + j) % 3;
                    if (r0 == 1 & j == 1) { m1 = Math.Min(m1, difference + min1); }
                    else if (r0 == 1 & j == 2) { m1 = Math.Min(m1, difference + min2); }
                    else if (r0 == 2 & j == 1) { m2 = Math.Min(m2, difference + min1); }
                    else if (r0 == 2 & j == 2) { m2 = Math.Min(m2, difference + min2); }
                }
                if (ostat_ot_del == 1) { m1 = Math.Min(m1, difference); }
                else { m2 = Math.Min(m2, difference); }
                min1 = m1; min2 = m2;
            }
        }
        if (answer % 3 == 0) { Console.WriteLine(answer); }
        else if ((answer % 3 == 1) && (Math.Abs(answer - min1) % 3 == 0) && (answer - min1) > 0) { Console.WriteLine(answer - min1); }
        else if ((answer % 3 == 2) && (Math.Abs(answer - min2) % 3 == 0) && (answer - min2) > 0) { Console.WriteLine(answer - min2); }
        else { Console.WriteLine("Sum is not exist"); }              
    }
}
