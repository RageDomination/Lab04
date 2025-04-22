using System;

namespace CityApp
{
    class City
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public int Population { get; set; }
        public double AnnualIncome { get; set; }
        public double Area { get; set; }
        public bool HasPort { get; set; }
        public bool HasAirport { get; set; }

        public double CalculateIncomePerPerson()
        {
            return Population > 0 ? AnnualIncome / Population : 0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            City city = new City();

            Console.Write("Введiть назву мiста: ");
            city.Name = Console.ReadLine();

            Console.Write("Введiть країну: ");
            city.Country = Console.ReadLine();

            Console.Write("Введiть регiон: ");
            city.Region = Console.ReadLine();

            city.Population = ReadInt("Введiть кiлькiсть населення: ");
            city.AnnualIncome = ReadDouble("Введiь рiчний дохiд мiста: ");
            city.Area = ReadDouble("Введiть площу мiста (кв.км): ");
            city.HasPort = ReadBool("Чи має мiсто порт? (true/false): ");
            city.HasAirport = ReadBool("Чи має мiсто аеропорт? (true/false): ");

            double incomePerPerson = city.CalculateIncomePerPerson();

            Console.WriteLine("\n--- Iнформацiя про мiсто ---");
            Console.WriteLine($"Назва мiста: {city.Name}");
            Console.WriteLine($"Країна: {city.Country}");
            Console.WriteLine($"Регiон: {city.Region}");
            Console.WriteLine($"Населення: {city.Population}");
            Console.WriteLine($"Рiчний дохiд: {city.AnnualIncome} грн");
            Console.WriteLine($"Площа: {city.Area} кв.км");
            Console.WriteLine($"Наявнiсть порту: {(city.HasPort ? "так" : "нi")}");
            Console.WriteLine($"Наявнiсть аеропорту: {(city.HasAirport ? "так" : "нi")}");
            Console.WriteLine($"Дохiд на одного мешканця: {incomePerPerson:F2} грн");

            Console.WriteLine("\nНатиснiть Enter для завершення.");
            Console.ReadLine();
        }

        static int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.WriteLine("Помилка! Введiть цiле додатнє число.\n");
            }
        }

        static double ReadDouble(string prompt)
        {
            double value;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out value) && value >= 0)
                    return value;
                Console.WriteLine("Помилка! Введiть число бiльше або рiвне нулю.\n");
            }
        }

        static bool ReadBool(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "true" || input == "так") return true;
                if (input == "false" || input == "ні") return false;
                Console.WriteLine("Помилка! Введiть 'true' (або 'так') чи 'false' (або 'нi').\n");
            }
        }
    }
}
