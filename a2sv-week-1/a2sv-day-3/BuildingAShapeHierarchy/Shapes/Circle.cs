namespace BuildingAShapeHierarchy.Shapes;

class Circle : Shape {
    private double Radius;

    internal Circle(string name, double radius) : base(name) => Radius = radius;

    internal override double CalculateArea() => Math.PI * Radius * Radius;
}