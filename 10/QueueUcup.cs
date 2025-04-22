using System;

public class Queue
{
    public string[] Items;
    private int front;
    private int rear;
    private int count;

    public Queue(int capacity)
    {
        Items = new string[capacity];
        front = 0;
        rear = -1;
        count = 0;
    }

    public void Enqueue(string value)
    {
        if (rear < Items.Length - 1)
        {
            Items[++rear] = value;
            count++;
        }
    }

    public string Peek()
    {
        return Items[front];
    }

    public void Dequeue()
    {
        if (count > 0)
        {
            front++;
            count--;
        }
    }

    public int Count => count;
}

public class Program
{
    public static void Main()
    {
        string[] submitted = Console.ReadLine().Split();
        string[] graded = Console.ReadLine().Split();

        Queue queue = new Queue(1000); 

        for (int i = 0; i < submitted.Length; i++)
        {
            queue.Enqueue(submitted[i]);
        }

        for (int i = 0; i < graded.Length; i++)
        {
            if (queue.Count == 0 || queue.Peek() != graded[i])
            {
                Console.WriteLine("Salah Ucup");
            }
            else
            {
                queue.Dequeue();
            }
        }

        Console.WriteLine(queue.Count);
    }
}
