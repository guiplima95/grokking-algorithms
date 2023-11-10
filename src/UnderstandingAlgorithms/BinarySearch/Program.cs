using System.Reflection;
using System.Runtime.CompilerServices;

namespace BinarySearch;

class Program
{
    public static readonly int _myNumber = new Random().Next(1, 100);

    public static List<Option>? options;

    static void Main(string[] args)
    {
        options = new List<Option>
        {
            new Option("I like it, I want to choice a number!", () => SearchBinary()),
            new Option("Damn it, I don't want to play :(", () => Environment.Exit(0)),
        };

        int index = 0;

        WriteMenu(options, options[index]);

        ConsoleKeyInfo keyinfo;

        do
        {
            keyinfo = Console.ReadKey();


            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < options.Count)
                {
                    index++;
                    WriteMenu(options, options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    WriteMenu(options, options[index]);
                }
            }
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                options[index].Selected.Invoke();
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);

        Console.ReadKey();

    }

    static void WriteMenu(List<Option> options, Option selectedOption)
    {
        Console.Clear();

        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("Welcome to my first algorithm series: Understanding Algorithms!");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("In this algorithm, I have a list of number and I'm thinking in a specific number between 1 to 100, can you discover in min attemps possible??");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------------");

        foreach (Option option in options)
        {
            if (option == selectedOption)
            {
                Console.Write("> ");
            }
            else
            {
                Console.Write(" ");
            }

            Console.WriteLine(option.Name);
        }
    }


    static void SearchBinary()
    {
        Console.Clear();
        Console.WriteLine("What's the number?");

        try
        {
            bool check = false;
            int attempts = 0;
            int numberChoiced = Convert.ToInt32(Console.ReadLine());

            int[] items = new int[100];

            int down = 0;
            int middle = 0;
            int up = items.Length - 1;

            do
            {
                if (attempts >= 1)
                {
                    Console.WriteLine("Choice another number!");
                    numberChoiced = Convert.ToInt32(Console.ReadLine());
                }

                middle = (down + up) / 2;

                if (numberChoiced == _myNumber)
                {
                    check = true;
                }
                else
                {
                    ValidateChoice(numberChoiced, ref down, middle, ref up);
                    attempts++;
                }
            }
            while (down <= up);

            if (check)
            {
                Console.WriteLine($"Congrats man!!! You won... :D -----> You did it with {attempts} attemps <----");
                Environment.Exit(0);
            }

            if (down >= up)
            {
                Console.WriteLine($"You are passed the limit of attemps for this search binary. Try again from the beginning...");
            }
        }
        catch (Exception)
        {
            Console.WriteLine("This doesn't a number! :(");
        }
    }

    private static void ValidateChoice(int numberChoiced, ref int down, int middle, ref int up)
    {
        if (numberChoiced > _myNumber)
        {
            up = middle - 1;
            Console.WriteLine("Your choice was a litle up! Try again.");
        }
        else
        {
            down = middle + 1;
            Console.WriteLine("Your choice was a litle down! Try again.");
        }
    }

    //int item = 10;

    //int[] items = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

    //int down = 0;

    //int up = items.Length - 1;

    //int middle = 0;

    //int check = items[middle];

    //while (down <= up)
    //{
    //    middle = (down + up) / 2;
    //}

}

