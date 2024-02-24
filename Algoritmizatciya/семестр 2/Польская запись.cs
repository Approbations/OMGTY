static void Main(string[] args)
{
    Console.Write("Введите польскую запись через пробел: ");
    string[] input = Console.ReadLine().Split(); bool flag = true; int cI = 0; int c = 0;
    Stack<string> stack = new Stack<string>();
    foreach (string s in input) { stack.Push(s); if (int.TryParse(s, out _)) { cI++; } else { c++; } }
    if (!(cI - c == 1))
    {
        flag = false;
    }
    else
    {
        stack = Reverse(stack);
        while (stack.Count() >= 3)
        {
            stack = new Stack<string>(Polska(stack).ToArray());
        }
    }
    if (!flag || stack.Count() == 0)
    {
        Console.WriteLine("Ошибка");
    }
    else
    {
        Console.WriteLine("Answer = " + stack.Peek());
    }

}
static Stack<string> Polska(Stack<string> st)
{
    int num1, num2; bool n1, n2; string op = "+-*/";
    n1 = int.TryParse(st.Peek(), out num1); st.Pop();
    n2 = int.TryParse(st.Peek(), out num2); st.Pop();
    string operation = st.Peek(); st.Pop();
    if (!(n1 && n2) || (num2 == 0) || (!op.Contains(operation)))
    {
        return new Stack<string>();
    }
    switch (operation)
    {
        case "+":
            st.Push(Convert.ToString(num1 + num2));
            break;
        case "-":
            st.Push(Convert.ToString(num1 - num2));
            break;
        case "*":
            st.Push(Convert.ToString(num1 * num2));
            break;
        case "/":
            st.Push(Convert.ToString(num1 / num2));
            break;
    }
    return Reverse(st);
}
public static Stack<string> Reverse(Stack<string> input)
{
    Stack<string> temp = new Stack<string>();

    while (input.Count != 0)
        temp.Push(input.Pop());

    return temp;
}
