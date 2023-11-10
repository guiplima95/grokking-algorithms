namespace BinarySearch;

class Program
{
    public static readonly string[] items = { "Bahia", "Cruzeiro", "Santos", "Goias", "Coritiba" };

    static void Main()
    {
        Console.WriteLine($"Algorithm Binary Search: {Find(items, "Cruzeiro")}");
    }

    static int Find<T>(T[] items, T item) where T : IComparable<T>
    {
        int low = 0;
        int high = items.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;

            T guess = items[mid];

            if (guess.CompareTo(item) == 0)
            {
                return mid;
            }

            if (guess.CompareTo(item) > 0)
            {
                high = mid - 1;
            }

            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }
}

