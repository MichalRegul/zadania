using System;
using System.IO;

class Program
{
    static void Main()
    {
        string line;
        string filePath = "C:\\test_MichalRegula.txt";

        try
        {
            string text = File.ReadAllText(filePath);
            StreamReader sr = new StreamReader("C:\\test_MichalRegula.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
            int count = counthowmany(text, 'a');
            Console.WriteLine("Liczba wystąpień litery 'a': " + count);
            Console.ReadLine();
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Plik nie został znaleziony.");
        }
        static int counthowmany(string text, char character)
        {
            int count = 0;
            foreach (char c in text)
            {
                if (c == character)
                {
                    count++;
                }
            }
            return count;
        }
    }
}