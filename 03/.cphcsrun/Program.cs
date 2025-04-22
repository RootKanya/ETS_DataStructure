using System;

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();
        int[] numbers = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            numbers[i] = int.Parse(input[i]);
        }

        int target = int.Parse(Console.ReadLine());

        int left = 0;
        int right = numbers.Length - 1;
        int count = 0;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (numbers[mid] == target)
            {
                Console.WriteLine(count);
                return;
            }
            else if (target > numbers[mid])
            {
                count++; // increment only when splitting
                left = mid + 1;
            }
            else
            {
                count++; // increment only when splitting
                right = mid - 1;
            }
        }

        Console.WriteLine("Tidak ada");
    }
}
