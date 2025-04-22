using System;

class Node
{
    public int Value;
    public Node Next;
    public Node Prev;

    public Node(int value)
    {
        Value = value;
        Next = null;
        Prev = null;
    }
}

class DoubleLinkedList
{
    public Node Head;
    public Node Tail;

    public void AddLast(int value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            newNode.Prev = Tail;
            Tail = newNode;
        }
    }

    public void RemoveFront(int x)
    {
        while (x-- > 0 && Head != null)
        {
            Head = Head.Next;
            if (Head != null) Head.Prev = null;
            else Tail = null;
        }
    }

    public void RemoveBack(int x)
    {
        while (x-- > 0 && Tail != null)
        {
            Tail = Tail.Prev;
            if (Tail != null) Tail.Next = null;
            else Head = null;
        }
    }

    public void Print()
    {
        if (Head == null)
        {
            Console.WriteLine("Sedang memotong angin");
            return;
        }

        Node current = Head;
        while (current != null)
        {
            Console.Write(current.Value);
            if (current.Next != null) Console.Write(" ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    public static void Main()
    {
        string[] elements = Console.ReadLine().Split();
        DoubleLinkedList list = new DoubleLinkedList();
        foreach (string e in elements)
        {
            list.AddLast(int.Parse(e));
        }

        string[] ops = Console.ReadLine().Split();
        foreach (string op in ops)
        {
            if (op.Length == 2)
            {
                int count = op[0] - '0';
                char type = op[1];

                if (type == 'A') list.RemoveFront(count);
                else if (type == 'B') list.RemoveBack(count);
            }
        }

        list.Print();
    }
}
