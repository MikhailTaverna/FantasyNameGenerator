using System;
using System.IO;

namespace FantasyNameGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string name;
            string location;
            int command = 0;
            Random randomIndex = new Random();
            string[] maleNames;
            string[] femaleNames;
            string[] locations;

            try
            {
                maleNames = File.ReadAllLines("MaleNames.txt");
                femaleNames = File.ReadAllLines("FemaleNames.txt");
                locations = File.ReadAllLines("Locations.txt");
            }
            catch
            {
                Console.WriteLine("Файлы с именами не найдены или повреждены");
                Console.ReadKey();
                return;
            }


            while (true)
            {
                Console.WriteLine("Введите команду:\t1 - Сгенерировать мужское имя\t2 - Сгенерировать женское имя\t0 - Выход");
                location = locations[randomIndex.Next(locations.Length)];
                bool isCommandCorrect = int.TryParse(Console.ReadLine(), out command);
                if(isCommandCorrect == false)
                {
                    Console.WriteLine("Команда не найдена\n");
                    continue;
                }
                switch (command)
                {
                    case 1:
                        name = maleNames[randomIndex.Next(maleNames.Length)];
                        Console.WriteLine($"{name} of {location}");
                        break;
                    case 2:
                        name = femaleNames[randomIndex.Next(femaleNames.Length)];
                        Console.WriteLine($"{name} of {location}");
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Команда не найдена\n");
                        break;
                }
            }
        }
    }
}
