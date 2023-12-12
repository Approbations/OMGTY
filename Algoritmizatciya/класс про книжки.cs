internal class Program
{
    static void Main(string[] args)
    {
        int sortYear = 2000; string sortName = "Chuck Palanik", sortTitle = "The surviror";
        Book[] books = new Book[6];
        books[0] = new Book("Chuck Palanik", "The surviror", 1999, ["March", "April"]);
        books[1] = new Book("Julia Enders", "Charming intestines", 2016, ["January"]);
        books[2] = new Book("Thomas Canels", "Schindler's list", 1982, ["September", "November", "December"]);
        books[3] = new Book("Alexey Chernenko", "Lord Dark. Mercenary", 2012, ["July"]);
        books[4] = new Book("Chuck Palanik", "Fight club", 1996, ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"]);
        books[5] = new Book("Siril Massarotto", "100 clear pages", 2011, ["August"]);

        Console.WriteLine("Сколько раз была выдана каждая книга ");

        for (int i = 0; i < books.Length; i++)
        {
            Book book = books[i];
            Console.WriteLine(book.Title + '\t' + book.Date_Of_Issue.Count() + " раз(а)");
            
        }

        Console.WriteLine("\n" + "Выборка по году издания, которые больше " + sortYear);

        for (int i = 0; i < books.Length; i++)
        {
            Book book = books[i];
            if (book.sortByYear(book, sortYear) != null)
            {
                Console.WriteLine(book.getBookInformation(book.sortByYear(book, sortYear)));
            }
        }

        Console.WriteLine("\n" + "Все книги " + sortName);

        for (int i = 0; i < books.Length; i++)
        {
            Book book = books[i];
            if (book.sortByAuthor(book, sortName) != null)
            {
                Console.WriteLine(book.getBookInformation(book.sortByAuthor(book, sortName)));
            }
        }

        Console.WriteLine($"\nВсе данные о книге {sortTitle}: ");
        for (int i = 0; i < books.Length; i++)
        {
            Book book = books[i];
            if (book.sortByTitle(book, sortTitle) != null)
            {
                Console.WriteLine(book.getBookInformation(book.sortByTitle(book, sortTitle)));
            }
        }
    }
}
class Book
{
    
    private String author; String title; private int publication; private String[] date_of_issue;
    public Book(String author, String title, int publication, String[] date_of_issue)
    {
        this.author = author;
        this.title = title;
        this.publication = publication;
        this.date_of_issue = date_of_issue;
    }

    public Book sortByAuthor(Book book, String author)
    {
        if (book.author.Equals(author))
        {
            return book;
        }
        return null;
    }

    public Book sortByYear(Book book, int year)
    {
        if (book.publication > year)
        {
            return book;
        }
        return null;
    }

    public Book sortByTitle(Book book, String title)
    {
        if (book.title.Equals(title))
        {
            return book;
        }
        return null;
    }

    public String getBookInformation(Book book)
    {
        return book.author + '\t' + book.title + "\t" + book.publication + "\t" + String.Join(" ", book.date_of_issue);
    }
    public int Publication
    {
        get { return publication; }
        set { this.publication = value; }
    }

    public String[] Date_Of_Issue
    {
        get { return this.date_of_issue; }
        set { this.date_of_issue = value; }
    }

    public String Title
    {
        get { return this.title; }
        set { this.title = value; }
    }
    
}
