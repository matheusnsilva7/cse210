public class Square : Shape
{
    private double _site;
    public Square(string color, double side) : base(color)
    {
        _site = side;
    }

    public override double GetArea()
    {
        return _site * _site;
    }
}