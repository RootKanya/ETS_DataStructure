using System;

class Node
{
    public string Data;
    public Node Next;

    public Node(string data)
    {
        Data = data;
        Next = null;
    }
}

class LinkedList
{
    private Node head;

    public void AddLast(string data)
    {
        Node newNode = new Node(data);
        if (head == null)
        {
            head = newNode;
            return;
        }

        Node current = head;
        while (current.Next != null)
            current = current.Next;

        current.Next = newNode;
    }

    public void Remove(string data)
    {
        if (head == null) return;

        if (head.Data == data)
        {
            head = head.Next;
            return;
        }

        Node current = head;
        while (current.Next != null && current.Next.Data != data)
        {
            current = current.Next;
        }

        if (current.Next != null)
        {
            current.Next = current.Next.Next;
        }
    }

    public bool Contains(string data)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data == data)
                return true;
            current = current.Next;
        }
        return false;
    }

    public void PrintAll()
    {
        Node current = head;
        while (current != null)
        {
            Console.WriteLine(current.Data);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        LinkedList belanja = new LinkedList();

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            if (input.StartsWith("BELI "))
            {
                string snack = input.Substring(5);
                belanja.AddLast(snack);
            }
            else if (input.StartsWith("KELUAR "))
            {
                string snack = input.Substring(7);
                belanja.Remove(snack);
            }
            else if (input.StartsWith("CARI "))
            {
                string snack = input.Substring(5);
                if (belanja.Contains(snack))
                    Console.WriteLine("Gotcha!");
                else
                    Console.WriteLine("Sad!");
            }
            else if (input == "PRINT")
            {
                belanja.PrintAll();
            }
        }
    }
}
