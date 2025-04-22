using System;

class Node
{
    public int Data;
    public Node Next;

    public Node(int data)
    {
        Data = data;
        Next = null;
    }
}

class Queue
{
    private Node front;
    private Node rear;

    public void Enqueue(int data)
    {
        Node newNode = new Node(data);
        if (rear == null)
        {
            front = rear = newNode;
            return;
        }
        rear.Next = newNode;
        rear = newNode;
    }

    public int Dequeue()
    {
        if (front == null) return -1;

        int data = front.Data;
        front = front.Next;

        if (front == null)
            rear = null;

        return data;
    }

    public bool IsEmpty()
    {
        return front == null;
    }

    public void PrintAll()
    {
        if (IsEmpty())
        {
            Console.WriteLine("-1");
            return;
        }

        Node current = front;
        while (current != null)
        {
            Console.Write(current.Data);
            if (current.Next != null)
                Console.Write(" ");
            current = current.Next;
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        string[] input1 = Console.ReadLine().Split();
        int N = int.Parse(input1[0]);
        int X = int.Parse(input1[1]);

        int P = int.Parse(Console.ReadLine());

        Queue queue = new Queue();
        for (int i = 0; i < P; i++)
        {
            int Q = int.Parse(Console.ReadLine());
            queue.Enqueue(Q);
        }

        for (int turn = 1; turn <= N; turn++)
        {
            if (queue.IsEmpty()) break;

            int AnakDepan = queue.Dequeue();
            if (turn % X != 0)
                queue.Enqueue(AnakDepan); 
        }

        queue.PrintAll();
    }
}
