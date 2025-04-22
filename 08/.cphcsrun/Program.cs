using System;

public class Stack
{
    public char[] Items;
    private int top;

    public Stack(int capacity)
    {
        Items = new char[capacity];
        top = -1;
    }

    public bool CanAdd(char c)
    {
        return top == -1 || c <= Items[top];
    }

    public void Add(char c)
    {
        if (top < Items.Length - 1)
        {
            Items[++top] = c;
        }
    }

    public char Remove()
    {
        char topItem = Items[top];
        top--;
        return topItem;
    }

    public int Count => top + 1;

    public char Peek()
    {
        return Items[top];
    }

    public int TopIndex => top;
}

public class Program
{
    public static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        string boxLabels = Console.ReadLine();

        Stack[] stacks = new Stack[1000];
        int stackCount = 0;

        // Step 1: Arrange boxes into stacks
        foreach (char box in boxLabels)
        {
            bool placed = false;

            for (int i = 0; i < stackCount; i++)
            {
                if (stacks[i].CanAdd(box) && stacks[i].Count < 5)
                {
                    stacks[i].Add(box);
                    placed = true;
                    break;
                }
            }

            if (!placed)
            {
                stacks[stackCount] = new Stack(5);
                stacks[stackCount].Add(box);
                stackCount++;
            }
        }

        // Step 2: Print stacks (top to bottom)
        Console.WriteLine($"Jumlah Tumpukan: {stackCount}");
        for (int i = 0; i < stackCount; i++)
        {
            Console.Write("Stack " + (i + 1) + ": ");
            for (int j = stacks[i].TopIndex; j >= 0; j--)
            {
                Console.Write(stacks[i].Items[j] + " ");
            }
            Console.WriteLine();
        }

        // Step 3: Simulate the shipping process
        Console.WriteLine("Urutan Pengiriman:");

        int[] pointers = new int[stackCount]; // to track top index per stack
        for (int i = 0; i < stackCount; i++)
        {
            pointers[i] = stacks[i].TopIndex;
        }

        for (int shipped = 0; shipped < N; shipped++)
        {
            char minChar = '{'; // a char after 'Z'
            int chosenStack = -1;

            for (int i = 0; i < stackCount; i++)
            {
                if (pointers[i] >= 0)
                {
                    char topChar = stacks[i].Items[pointers[i]];
                    if (topChar < minChar)
                    {
                        minChar = topChar;
                        chosenStack = i;
                    }
                }
            }

            if (chosenStack != -1)
            {
                Console.WriteLine($"Kirim kardus tujuan {stacks[chosenStack].Items[pointers[chosenStack]]} dari Stack {chosenStack + 1}");
                pointers[chosenStack]--;
            }
        }
    }
}
