namespace BuildingAShapeHierarchy.Shapes;

class Rectangle : Shape {
    private double Width;
    private double Height;


    internal Rectangle(string name, double width, double height) : base(name) => (Width, Height) = (width, height);

    internal override double CalculateArea() => Width * Height;
}