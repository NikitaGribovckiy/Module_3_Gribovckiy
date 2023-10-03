using System;

// Класс "Прямоугольник"
class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    // Конструктор класса Прямоугольник, принимающий ширину и высоту
    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    // Переопределение метода CalculateArea для прямоугольника
    public override double CalculateArea()
    {
        return Width * Height; // Вычисление площади прямоугольника
    }
}