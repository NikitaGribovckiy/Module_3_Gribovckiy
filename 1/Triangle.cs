using System;

// Класс "Треугольник"
class Triangle : Shape
{
    public double BaseLength { get; set; }
    public double Height { get; set; }

    // Конструктор класса Треугольник, принимающий длину основания и высоту
    public Triangle(double baseLength, double height)
    {
        BaseLength = baseLength;
        Height = height;
    }

    // Переопределение метода CalculateArea для треугольника
    public override double CalculateArea()
    {
        return 0.5 * BaseLength * Height; // Вычисление площади треугольника
    }
}
