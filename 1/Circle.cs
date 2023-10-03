using System;

// Класс "Круг"
class Circle : Shape
{
    public double Radius { get; set; }

    // Конструктор класса Круг, принимающий радиус
    public Circle(double radius)
    {
        Radius = radius;
    }

    // Переопределение метода CalculateArea для круга
    public override double CalculateArea()
    {
        return Math.PI * Radius * Radius; // Вычисление площади круга
    }
}