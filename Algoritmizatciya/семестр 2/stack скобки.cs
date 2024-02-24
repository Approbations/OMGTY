Stack<char> mystack = new Stack<char>(); string input = Console.ReadLine(); bool flag = true;
if (input.Count(i => i == '(') != input.Count(i => i == ')') || input.Count(i => i == '[') != input.Count(i => i == ']')
    || input.Count(i => i == '{') != input.Count(i => i == '}')) { flag = false; }
if (flag) { 
foreach (char line in input)
{
    switch (line)
    {
        case '(':
            mystack.Push('(');
            break;
        case '[':
            mystack.Push('[');
            break;
        case '{':
            mystack.Push('{');
            break;
        case ')':
            if (mystack.Peek() != '(')
            {
                flag = false;
            }
            mystack.Pop();
            break;
        case ']':
            if (mystack.Peek() != '[')
            {
                flag = false;
            }
            mystack.Pop();
            break;
        case '}':
        if (mystack.Peek() != '{')
            {
                flag = false;
            }
            mystack.Pop();
            break;
    }
}}
if (flag)
{
    Console.WriteLine("Yes");
}
else
{
    Console.WriteLine("No");
}
