using System;

class Program
{
    class CharStack
    {
        private char[] data;
        private int top;

        public CharStack(int size)
        {
            data = new char[size];
            top = -1;
        }

        public void Push(char c)
        {
            if (top < data.Length - 1)
            {
                data[++top] = c;
            }
        }

        public char Pop()
        {
            if (top >= 0)
            {
                return data[top--];
            }
            return '\0'; 
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
    }

    static void Main()
    {
        string input = Console.ReadLine();
        CharStack stack = new CharStack(input.Length);

        for (int i = 0; i < input.Length; i++)
        {
            stack.Push(input[i]);
        }

        string reversed = "";
        while (!stack.IsEmpty())
        {
            reversed += stack.Pop();
        }

        if (input == reversed)
        {
            Console.WriteLine("Ya");
        }
        else
        {
            Console.WriteLine("Tidak");
        }
    }
}


