using System;
using System.IO;
using System.Text;


    class Program
    {
        static void Main(string[] args)
        {
            // pobranie ścieżki do zapisu pliku od użytkownika
            Console.Write("Podaj ścieżkę do zapisu pliku: ");
            string outputPath = Console.ReadLine();

            // wygenerowanie nazwy pliku na podstawie bieżącej daty i godziny
            string timestamp = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss").Replace("-", "_").Replace(":", "_");
            string fileName = $"users-{timestamp}.csv";

            // pełna ścieżka do pliku
            string filePath = Path.Combine(outputPath, fileName);

            // generowanie i zapisywanie użytkowników do pliku CSV
            GenerateUsers(filePath, 100);

            Console.WriteLine("Generowanie użytkowników zakończone.");
            Console.WriteLine($"Plik został zapisany jako: {filePath}");
            Console.ReadLine();
        }

        // generowanie użytkowników
        static void GenerateUsers(string filePath, int count)
        {
            // tworzenie nagłówka pliku CSV
            string[] header = { "LP", "Imię", "Nazwisko", "Rok urodzenia" };

            // generowanie użytkowników
            Random random = new Random();
            StringBuilder csvData = new StringBuilder();

            csvData.AppendLine(string.Join(",", header));

            for (int i = 1; i <= count; i++)
            {
                string[] user = new string[4];

                user[0] = i.ToString();
                user[1] = GetRandomName(random);
                user[2] = GetRandomSurname(random);
                user[3] = random.Next(1990, 2001).ToString();

                csvData.AppendLine(string.Join(",", user));
            }

            // zapisywanie danych do pliku CSV
            File.WriteAllText(filePath, csvData.ToString());
        }

        static string GetRandomName(Random random)
        {
            string[] names = { "Ania", "Kasia", "Basia", "Zosia" };
            return names[random.Next(names.Length)];
        }

        static string GetRandomSurname(Random random)
        {
            string[] surnames = { "Kowalska", "Nowak" };
            return surnames[random.Next(surnames.Length)];
        }
    }