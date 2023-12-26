internal class Program
{
    static void Main(string[] args)
    {
        string ws = "1"; string past = "";
        Workshop[] workshops = new Workshop[8];
        workshops[0] = new Workshop("1", 1988, 90);
        workshops[1] = new Workshop("1", 2007, 60);
        workshops[2] = new Workshop("1", 2012, 74);
        workshops[3] = new Workshop("2", 1999, 20);
        workshops[4] = new Workshop("2", 2000, 50);
        workshops[5] = new Workshop("2", 2009, 28);
        workshops[6] = new Workshop("3", 2020, 89);
        workshops[7] = new Workshop("3", 2021, 84);
        
        Console.WriteLine("Суммарный объем выпуска каждого цеха");
        past = workshops[0].Name; int count = 0;
        for (int i = 0; i < workshops.Length; i++)
        {
            if (past == workshops[i].Name)
            {
                count += workshops[i].Grands;
            }
            else
            {
                Console.WriteLine(past + " " + count);
                past = workshops[i].Name;
                count = workshops[i].Grands;
            }
        }
        Console.WriteLine(past + " " + count);

        Console.WriteLine($"Интенсивность производства цеха {ws} по каждому году");
        for (int i = 0 ; i < workshops.Length ; i++)
        {
            if (workshops[i].Name.Equals(ws))
            {
                Console.WriteLine(workshops[i].getIntensity(workshops[i]));
            }
        }
    }
}


class Workshop
{
    private string name; private int year; private int grands;
    public Workshop(string name, int year, int grands)
    {
        this.name = name;
        this.year = year;
        this.grands = grands;
    }

    public string getIntensity(Workshop workshop)
    {
        return workshop.year + " " + Convert.ToString(Math.Round(workshop.Grands * 0.1 / 365, 4));
    }

    public String Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
    public int Year
    {
        get { return this.year; }
        set { this.year = value; }
    }

    public int Grands
    {
        get { return this.grands; }
        set { this.grands = value; }
    }
}
