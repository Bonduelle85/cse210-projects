using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Polymorphism!");
        Square square = new Square(2.0, "Blue");
        Console.WriteLine($"{square.GetColor()} {square.ToString()} with area {square.GetArea()}");

        Rectangle rectangle = new Rectangle(3.0, 3.0, "Green");
        Console.WriteLine($"{rectangle.GetColor()} {rectangle.ToString()} with area {rectangle.GetArea()}");

        Circle circle = new Circle(5.0, "Yellow");
        Console.WriteLine($"{circle.GetColor()} {circle.ToString()} with area {circle.GetArea()}");

        Console.WriteLine($"\nPolymorphism:");
        List<Shape> shapes = new List<Shape> {square, rectangle, circle};

        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.GetColor()} {shape.ToString()} with area {shape.GetArea()}");
        }
    }
}