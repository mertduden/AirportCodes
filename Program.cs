using System;
using System.IO;

namespace AirportCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            string arg;

            Console.WriteLine("This console program lets you search IATA/ICAO airport codes.");
            Console.WriteLine("Retreiving data..");

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] cities = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "cities.txt"));
            string[] icao = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "icao.txt"));
            string[] iata = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "iata.txt"));
            string[] names = System.IO.File.ReadAllLines(Path.Combine(Environment.CurrentDirectory, @"Data\", "names.txt"));

            Console.WriteLine("Data retreived.");
            Console.WriteLine("Enter an IATA or ICAO code below: ");

            arg = Console.ReadLine();

            getAirportInfo(icao, arg);
            getAirportInfo(iata, arg);


            while (arg != "X")
            {
                Console.WriteLine("  ");
                Console.WriteLine("-------------------------------- ");
                Console.WriteLine("Enter an IATA or ICAO code below: ");
                Console.WriteLine("To exit, please type X: ");

                arg = Console.ReadLine();
                getAirportInfo(icao, arg);
                getAirportInfo(iata, arg);
            }

            void getAirportInfo (string [] list, string check)
            {
                int count = 0;
                foreach (var name in list)
                {
                    if (name.Equals(check))
                    {
                        Console.WriteLine("-----------------");
                        Console.WriteLine($"ICAO Code: {icao[count]}");
                        Console.WriteLine($"IATA Code: {iata[count]}");
                        Console.WriteLine($"Airport Name: {names[count]}");
                        Console.WriteLine($"Airport City: {cities[count]}");
                    }
                    count++;
                }
            }
            
        }
    }
}
