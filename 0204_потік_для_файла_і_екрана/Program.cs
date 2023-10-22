using System;
using System.IO;
using System.Threading;

namespace UkrainianAlphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string ukrainianAlphabet = GetUkrainianAlphabetString(',');

            Thread consoleThread = new Thread(() => PrintToConsole(ukrainianAlphabet));
            Thread fileThread = new Thread(() => WriteToFile(ukrainianAlphabet));

            fileThread.Start();
            Thread.Sleep(200);
            consoleThread.Start();
        }

        static string GetUkrainianAlphabetString(char separator)
        {
            string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
            return string.Join(separator, alphabet.ToCharArray());
        }

        static void PrintToConsole(string data)
        {
            Console.WriteLine("Український алфавіт:");
            for (int i = 0; i < data.Length; i++)
            {
                Console.Write(data[i]);
                Thread.Sleep(50);
            }
        }

        static void WriteToFile(string data)
        {
            string path = "text.txt";
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Український алфавіт:");
                writer.WriteLine(data);
            }
            Console.WriteLine($"Дані було записано у файл {path}");
        }
    }
}
