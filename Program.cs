class opdracht1
{
    static void Main(string[] args)
    {
        double pi = CalculatePI();
        Console.WriteLine("{pi:F4}");
    }

    static double CalculatePI()
    {
        double pi = 0.0;

        for (int n = 0; n <= 100001; n++)
        {
            pi += (n % 2 == 0 ? 1 : -1) / (2.0 * n + 1);
        }

        return pi * 4;
    }


    class opdracht2
    {
        static string[] Words = { "LINGO", "ZWERK", "VEGER", "GROEN", "GOEDE" };

        static void Main(string[] args)
        {
            foreach (string word in Words)
            {
                Lingo(word);
            }

            Console.WriteLine("Alle woorden geraden!");
            Console.ReadLine();
        }

        static void Lingo(string word)
        {
            Console.WriteLine($"Raad het woord van {word.Length} letters:");

            string guess = Console.ReadLine().ToUpper();

            for (int i = 0; i < word.Length; i++)
            {
                if (guess[i] == word[i])
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else if (word.Contains(guess[i]))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ResetColor();
                }

                Console.Write(guess[i]);
            }

            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}



class opdracht3
{
    static void Main(string[] args)
    {
        Console.WriteLine("Voer postcode in:");
        string postcode = Console.ReadLine().Replace(" ", "");

        bool isValid = postcode.Length == 6 && IsNumeric(postcode.Substring(0, 4)) && IsAlpha(postcode.Substring(4));

        if (isValid)
        {
            Console.WriteLine("postcode is juist.");
        }
        else
        {
            Console.WriteLine("postcode is onjuist.");
        }

        Console.ReadLine();
    }

    static bool IsNumeric(string input)
    {
        return int.TryParse(input, out _);
    }

    static bool IsAlpha(string input)
    {
        return !string.IsNullOrEmpty(input) && input.ToUpper() == input.ToLower();
    }
}


class opdracht4
{
    static void Main(string[] args)
    {
        int count = 0;
        int number = 2;

        Console.WriteLine("De eerste 20 priemgetallen:");

        while (count < 20)
        {
            if (IsPrime(number))
            {
                Console.Write(number + " ");
                count++;
            }

            number++;
        }

        Console.ReadLine();
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }
}

class opdracht5
{
    static void Main(string[] args)
    {
        Console.WriteLine("Voer een woord in:");
        string word = Console.ReadLine();

        bool isPalindrome = IsPalindrome(word);

        Console.WriteLine(isPalindrome ? "Het woord is een palindroom." : "Het woord is geen palindroom.");

        Console.ReadLine();
    }

    static bool IsPalindrome(string word)
    {
        return word == new string(word.Reverse().ToArray(), 0, word.Length);
    }

    class opdracht6
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Voer een zin in:");
            string sentence = Console.ReadLine();

            string pigLatin = string.Join(" ", sentence.ToLower()
                .Split(' ')
                .Select(word =>
                {
                    word = word.Replace("j", "i").Replace("y", "").Replace("z", "");
                    return IsVowel(word[0]) ? word + "ibus" :
                           IsAIOLastChar(word) ? word + "nt" :
                           word[FindFirstVowelIndex(word)..] + word[..FindFirstVowelIndex(word)] + "itum";
                }));

            Console.WriteLine("In Varkenslatijn: " + pigLatin);

            Console.ReadLine();
        }

        static bool IsVowel(char c)
        {
            return "aeiou".Contains(c);
        }

        static bool IsAIOLastChar(string word)
        {
            return "aiu".Contains(word.Last());
        }

        static int FindFirstVowelIndex(string word)
        {
            return word.IndexOfAny(new[] { 'a', 'e', 'i', 'o', 'u' });
        }
    }
}