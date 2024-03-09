    static void Main(string[] args)
    {
        String sortEducation = "None", sortName = "Fill";
        int sortYear = 2000;


        Person[] persons = new Person[10];

        persons[0] = new Person("Adolf", 1889, "Second", "27 Line, 47");
        persons[1] = new Person("Lelud", 1997, "Higher", "5 Line, 7");
        persons[2] = new Person("Perkosrak", 2000, "Second", "6 Line, 47");
        persons[3] = new Person("Traktorina", 2000, "None", "7 Line, 47");
        persons[4] = new Person("Abdula", 1976, "Professor", "8 Line, 40");
        persons[5] = new Person("Berl", 1891, "None", "27 Line, 40");
        persons[6] = new Person("Trolebuzina", 2002, "Higher", "7 Line, 12");
        persons[7] = new Person("Mark", 2010, "Second", "7 Line, 13");
        persons[8] = new Person("Piter", 1988, "Second", "10 Line, 47");
        persons[9] = new Person("Mashunya", 2022, "None", "25 Line, 40");

        Console.WriteLine("Выборка по образованию типа: " + sortEducation);

        for (int i = 0; i < persons.Length; i++)
        {
            Person person = persons[i];
            if (person.sortByEducation(person, sortEducation) != null)
            {
                Console.WriteLine(person.getPersonInformation(person.sortByEducation(person, sortEducation)));
            }
        }

        Console.WriteLine("\n" + "Выборка по году рождения: " + sortYear);

        for (int i = 0; i < persons.Length; i++)
        {
            Person person = persons[i];
            if (person.sortByYear(person, sortYear) != null)
            {
                Console.WriteLine(person.getPersonInformation(person.sortByYear(person, sortYear)));
            }
            
        }
        Console.WriteLine("\n" + "Выборка по имени: " + sortName);

        for (int i = 0; i < persons.Length; i++)
        {
            Person person = persons[i];
            if (person.sortByName(person, sortName) != null)
            {
                Console.WriteLine(person.getPersonInformation(person.sortByName(person, sortName)));
            }
        }
    }
}
class Person
{
    
    private String name; private int year_of_birth; private String education; private String adress;
    public Person(String name, int year_of_bitrh, String education, String adress)
    {
        this.name = name;
        this.year_of_birth = year_of_bitrh;
        this.education = education;
        this.adress = adress;
    }

    public Person sortByName(Person person, String name)
    {
        if (person.name.Equals(name))
        {
            return person;
        }
        return null;
    }

    public Person sortByYear(Person person, int year)
    {
        if (person.year_of_birth == year)
        {
            return person;
        }
        return null;
    }

    public Person sortByEducation(Person person, String education)
    {
        if (person.education.Equals(education))
        {
            return person;
        }
        return null;
    }
    public String getPersonInformation(Person person)
    {
        return person.name + "\t" + Convert.ToString(person.year_of_birth) + "\t" + person.education + "\t" + person.adress;
    }
    public int YearOfBirth
    {
        get { return year_of_birth; }
        set { this.year_of_birth = value; }
    }

    public String Education
    {
        get { return this.education; }
        set { this.education = value; }
    }

    public String Adress
    {
        get { return this.adress; }
        set { this.adress = value; }
    }

    public String Name
    {
        get { return this.name; }
        set { this.name = value; }
    }
}
