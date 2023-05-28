static void Main()
    {
        // Aktualny kurs wymiany PLN na USD
        double kurs = 0.23;

        Console.WriteLine("Podaj kwotę w PLN: ");
        string input = Console.ReadLine();
        double kwotaPLN;

        if (double.TryParse(input, out kwotaPLN))
        {
            double kwotaUSD = kwotaPLN * kurs;
            Console.WriteLine("Kwota w USD: " + kwotaUSD);
        }
        else
        {
            Console.WriteLine("Nieprawidłowy format kwoty.");
        }

        Console.ReadLine();
    }
}