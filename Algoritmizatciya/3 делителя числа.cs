for (int i = 106732567; i <= 152673836; i++)
{
    if ((Math.Pow(i, 0.5) % 1 != 0) || (Math.Pow(i, 0.25) % 1 != 0))
    {
        continue;
    }
    double[] del = { Math.Pow(i, 0.25), Math.Pow(i, 0.5), Math.Pow(i, 0.75) };
    Console.WriteLine(i + " " + del.Max());
}
