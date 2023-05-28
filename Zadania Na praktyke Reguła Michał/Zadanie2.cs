using System;
using System.IO;

class Program
{
    static void Main()
    {
        
        string filePath = "C:\\zamienianie.txt";

        string originalWord = "praca";

        string replacementWord = "job";

        string content = File.ReadAllText(filePath);
        int count = counthowmany(content, originalWord);

       
        if (count == 5)
        {
            string replacedContent = content.Replace(originalWord, replacementWord);

            string changedFilePath = AddPostfixToFilePath(filePath, "_changed");
            File.WriteAllText(changedFilePath, replacedContent);

            Console.WriteLine("Zamieniono słowo praca na job i zapisano zmiany w pliku: {2}", originalWord, replacementWord, changedFilePath);
        }
        else
        {
            Console.WriteLine("Słowo klucz praca nie występuje pięć razy w pliku.", originalWord);
        }
    }

    static int counthowmany(string text, string word)
    {
        int count = 0;
        int index = 0;

        while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            count++;
            index += word.Length;
        }

        return count;
    }

    // dodawanie zmian do pliku tekstowego
    static string AddPostfixToFilePath(string filePath, string postfix)
    {
        string directory = Path.GetDirectoryName(filePath);
        string fileName = Path.GetFileNameWithoutExtension(filePath);
        string extension = Path.GetExtension(filePath);
        string date = DateTime.Now.ToString("yyyyMMdd");
        string changedFileName = $"{fileName}{postfix}-{date}{extension}";
        string changedFilePath = Path.Combine(directory, changedFileName);
        return changedFilePath;
    }
}
