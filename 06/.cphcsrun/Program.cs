using System;

class Program
{
    public class Food
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public Food(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }
    }

    static void Main()
    {
        string[] firstLine = Console.ReadLine().Split();
        int N = int.Parse(firstLine[0]);
        int Q = int.Parse(firstLine[1]);

        Food[] menu = new Food[N];
        for (int i = 0; i < N; i++)
        {
            string[] parts = Console.ReadLine().Split();
            menu[i] = new Food(parts[0], int.Parse(parts[1]));
        }

        string[] orders = new string[Q];
        for (int i = 0; i < Q; i++)
            orders[i] = Console.ReadLine();

        for (int i = 0; i < N - 1; i++)
        {
            for (int j = 0; j < N - i - 1; j++)
            {
                bool mustSwap =
                    menu[j].Priority > menu[j + 1].Priority ||
                    (menu[j].Priority == menu[j + 1].Priority && string.Compare(menu[j].Name, menu[j + 1].Name, StringComparison.Ordinal) > 0);
                if (mustSwap)
                {
                    var tmp = menu[j];
                    menu[j] = menu[j + 1];
                    menu[j + 1] = tmp;
                }
            }
        }

        Food[] ordered = new Food[Q];
        int idx = 0;
        for (int j = 0; j < N && idx < Q; j++)
        {
            for (int k = 0; k < Q; k++)
            {
                if (menu[j].Name == orders[k])
                {
                    ordered[idx++] = menu[j];
                    break;
                }
            }
        }

        for (int i = 0; i < Q; i++)
        {
            Console.WriteLine($"{i + 1}. {ordered[i].Name}");
        }
    }
}
