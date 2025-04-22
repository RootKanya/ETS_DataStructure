using System;

class Program
{
    static long M;

    static void Main()
    {
        string[] first = Console.ReadLine().Split();
        int K = int.Parse(first[0]);
        M       = long.Parse(first[1]);

        long[] A = new long[K];
        string[] parts = Console.ReadLine().Split();
        for (int i = 0; i < K; i++)
            A[i] = long.Parse(parts[i]);

        MergeSort(A, 0, K - 1);

        for (int i = 0; i < K; i++)
        {
            Console.Write(A[i]);
            if (i < K - 1) Console.Write(" ");
        }
        Console.WriteLine();
    }

    static void MergeSort(long[] A, int left, int right)
    {
        if (left >= right) return;
        int mid = (left + right) / 2;
        MergeSort(A, left, mid);
        MergeSort(A, mid + 1, right);
        Merge(A, left, mid, right);
    }

    static void Merge(long[] A, int left, int mid, int right)
    {
        int n1 = mid - left + 1;
        int n2 = right - mid;

        long[] L = new long[n1];
        long[] R = new long[n2];

        Array.Copy(A, left, L, 0, n1);
        Array.Copy(A, mid + 1, R, 0, n2);

        int i = 0, j = 0, k = left;
        while (i < n1 && j < n2)
        {
            if (Compare(L[i], R[j]) <= 0)
                A[k++] = L[i++];
            else
                A[k++] = R[j++];
        }
        while (i < n1) A[k++] = L[i++];
        while (j < n2) A[k++] = R[j++];
    }

    static int Compare(long a, long b)
    {
        long ea = (a * a) % M;
        long eb = (b * b) % M;
        if (ea < eb) return -1;
        if (ea > eb) return +1;
        if (a < b) return -1;
        if (a > b) return +1;
        return 0;
    }
}
