string obrazecsh = Console.ReadLine(); 
string now = Console.ReadLine();
int answer = 0;
while (now != "") {
    String[] temp = now.Split(new[] { obrazecsh }, StringSplitOptions.None);
    answer += temp.Length - 1;
    now = Console.ReadLine();
}
Console.WriteLine("кол-во вхождений " + answer);
