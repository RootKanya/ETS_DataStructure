using System;

class Program
{
    static void Main()
    {

        string[] inputLine = Console.ReadLine().Split();
        int[] numbers = new int[inputLine.Length];
        for (int i = 0; i < inputLine.Length; i++)
        {
            numbers[i] = int.Parse(inputLine[i]);
        }

        int x = int.Parse(Console.ReadLine());

        bool exists = false;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == x)
            {
                exists = true;
                break;
            }
        }

        if (exists)
        {
            Console.WriteLine("ADA");
        }
        else
        {
            Console.WriteLine("TIDAK ADA");
        }

        int count = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (x % numbers[i] == 0)
            {
                count++;
            }
        }

        Console.WriteLine(count);
    }
}
