using System;
using System.IO;

namespace FileIOApp
{
    class Program
    {
        static void Main(string[] args)
        {
            String filePath = @"C:\Users\APR Services\Desktop\test.txt";

            List<Person> people = new List<Person>();
            List<String> lines = File.ReadAllLines(filePath).ToList();

            foreach(string line in lines)
            {
                string[] entries = line.Split(' ');

                Person p = new Person();

                p.firstName = entries[0];
                p.lastName = entries[1];
                p.Url = entries[2];

                people.Add(p);
            }

            List<string> outputLines = new List<string>();
            Console.WriteLine("Here is the list of people: ");
            foreach(Person p in people)
            {
                Console.WriteLine("First Name: " + p.firstName + " Last Name: " + p.lastName + " Url: " + p.Url);
                outputLines.Add("First Name: " + p.firstName + " Last Name: " + p.lastName + " Url: " + p.Url);
            }

            string outPath = @"C:\Users\APR Services\Desktop\peopleOut.txt";
            File.WriteAllLines(outPath, outputLines);

            Console.ReadLine();

            
            /*List<String> lines = File.ReadAllLines(filePath).ToList();

            lines.Add("Steve, Jobs, www.apple.com");

            foreach (String line in lines)
            {
                Console.WriteLine(line);  
            }

            File.WriteAllLines(filePath, lines);*/


            Console.ReadLine();

        }
    }
}