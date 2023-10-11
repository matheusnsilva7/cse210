public class Circle : Shape
{
    private double _radios;
    public Circle(string color , double radios) : base(color)
    {
        _radios = radios;
    }

    public override double GetArea()
    {
        return 3.14159265359 * _radios * _radios;
    }
}