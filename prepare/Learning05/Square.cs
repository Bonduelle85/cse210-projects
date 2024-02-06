public class Square : Shape
{
    private double _side;

    public Square (double side , string color) : base(color)
    {
        _side = side;
    }


    override public double GetArea()
    {
        return _side * _side;
    }
}