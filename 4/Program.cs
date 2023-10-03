using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<DataRecord> data = new List<DataRecord>();

        Console.WriteLine("Введите данные (для завершения ввода введите 'Конец'):");

        while (true)
        {
            Console.Write("Введите текст: ");
            string input = Console.ReadLine();

            if (input == "Конец")
            {
                break; // Завершение ввода данных
            }

            string dateStr = "";

            while (true)
            {
                Console.Write("Введите дату написания текста (например, '2023-10-15'): ");
                dateStr = Console.ReadLine();

                if (IsValidDate(dateStr))
                {
                    break; // Правильный формат даты
                }
            }

            data.Add(new DataRecord(input, dateStr));
        }

        while (true)
        {
            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1. Фильтр по ключевым словам");
            Console.WriteLine("2. Фильтр по дате");
            Console.WriteLine("3. Выход");

            string choice = Console.ReadLine();

            if (choice == "3")
            {
                break; // Выход из программы
            }

            switch (choice)
            {
                case "1":
                    Console.Write("Введите текст для фильтрации: ");
                    string searchText = Console.ReadLine();
                    FilterData(data, s => s.Text.Contains(searchText));
                    break;

                case "2":
                    Console.Write("Введите дату для фильтрации: ");
                    string dateStr2 = Console.ReadLine();
                    FilterData(data, s => s.Date.Contains(dateStr2));
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите действие из списка.");
                    break;
            }
        }
    }

    // Метод для проверки корректности ввода даты
    private static bool IsValidDate(string dateStr)
    {
        if (DateTime.TryParse(dateStr, out DateTime result))
        {
            // Ввод даты корректен
            return true;
        }
        else
        {
            // Ввод даты некорректен
            Console.WriteLine("Некорректный формат даты. Пожалуйста, введите дату в формате 'гггг-мм-дд'.");
            return false;
        }
    }

    // Метод для фильтрации данных с использованием делегата
    static void FilterData(List<DataRecord> data, Func<DataRecord, bool> filter)
    {
        var filteredData = data.Where(filter).ToList();

        if (filteredData.Any())
        {
            Console.WriteLine("Результаты фильтрации:");
            foreach (var item in filteredData)
            {
                Console.WriteLine($"{item.Text} (Дата: {item.Date})");
            }
        }
        else
        {
            Console.WriteLine("Нет совпадений.");
        }

        Console.WriteLine();
    }
}
