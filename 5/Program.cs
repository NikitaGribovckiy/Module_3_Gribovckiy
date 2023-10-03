using System;

class Program
{
    static void Main(string[] args)
    {
        // Пользователь вводит числа для сортировки через пробел
        Console.WriteLine("Введите числа для сортировки (разделители - пробел):");
        string input = Console.ReadLine();
        string[] inputArray = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        int[] numbers = new int[inputArray.Length];
        for (int i = 0; i < inputArray.Length; i++)
        {
            // Парсинг введенных чисел
            if (int.TryParse(inputArray[i], out int number))
            {
                numbers[i] = number;
            }
            else
            {
                Console.WriteLine("Некорректный ввод числа.");
                return;
            }
        }

        // Создание объекта SortingManager для управления сортировкой
        SortingManager sortingManager = new SortingManager();

        while (true)
        {
            // Пользователь выбирает метод сортировки
            Console.WriteLine("Выберите метод сортировки:");
            Console.WriteLine("1. Сортировка пузырьком");
            Console.WriteLine("2. Быстрая сортировка");
            Console.WriteLine("3. Выход");

            string choice = Console.ReadLine();

            if (choice == "3")
            {
                break; // Выход из программы
            }

            Action<int[]> sortMethod = null;

            switch (choice)
            {
                case "1":
                    sortMethod = sortingManager.BubbleSort; // Установка метода сортировки пузырьком
                    break;
                case "2":
                    sortMethod = sortingManager.QuickSort; // Установка метода быстрой сортировки
                    break;
                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите метод сортировки из списка.");
                    break;
            }

            if (sortMethod != null)
            {
                int[] sortedNumbers = new int[numbers.Length];
                Array.Copy(numbers, sortedNumbers, numbers.Length);
                sortMethod(sortedNumbers); // Выполнение выбранной сортировки

                Console.WriteLine("Отсортированный массив:");
                foreach (int num in sortedNumbers)
                {
                    Console.Write($"{num} ");
                }
                Console.WriteLine();
            }
        }
    }
}