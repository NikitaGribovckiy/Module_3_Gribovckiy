using System;

class Program
{
    // Делегат для метода CalculateArea
    delegate double AreaDelegate();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Выберите фигуру для вычисления площади:");
            Console.WriteLine("1. Круг");
            Console.WriteLine("2. Прямоугольник");
            Console.WriteLine("3. Треугольник");
            Console.WriteLine("4. Выход");

            string choice = Console.ReadLine();

            if (choice == "4")
            {
                break; // Выход из программы
            }

            AreaDelegate areaDelegate = null;
            Shape selectedShape = null;

            switch (choice)
            {
                case "1":
                    Console.Write("Введите радиус круга: ");
                    if (double.TryParse(Console.ReadLine(), out double radius))
                    {
                        selectedShape = new Circle(radius); // Создание объекта Круг
                        areaDelegate = selectedShape.CalculateArea; // Присвоение делегату метода CalculateArea для Круга
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод для радиуса.");
                    }
                    break;

                case "2":
                    Console.Write("Введите ширину прямоугольника: ");
                    if (double.TryParse(Console.ReadLine(), out double width))
                    {
                        Console.Write("Введите высоту прямоугольника: ");
                        if (double.TryParse(Console.ReadLine(), out double height))
                        {
                            selectedShape = new Rectangle(width, height); // Создание объекта Прямоугольник
                            areaDelegate = selectedShape.CalculateArea; // Присвоение делегату метода CalculateArea для Прямоугольника
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод для высоты.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод для ширины.");
                    }
                    break;

                case "3":
                    Console.Write("Введите длину основания треугольника: ");
                    if (double.TryParse(Console.ReadLine(), out double baseLength))
                    {
                        Console.Write("Введите высоту треугольника: ");
                        if (double.TryParse(Console.ReadLine(), out double triangleHeight))
                        {
                            selectedShape = new Triangle(baseLength, triangleHeight); // Создание объекта Треугольник
                            areaDelegate = selectedShape.CalculateArea; // Присвоение делегату метода CalculateArea для Треугольника
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ввод для высоты.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректный ввод для длины основания.");
                    }
                    break;

                default:
                    Console.WriteLine("Некорректный выбор. Пожалуйста, выберите фигуру из списка.");
                    break;
            }

            if (areaDelegate != null)
            {
                double area = areaDelegate(); // Вызов метода CalculateArea с использованием делегата
                Console.WriteLine($"Площадь фигуры: {area}");
            }

            Console.WriteLine();
        }
    }
}