namespace BuildingAShapeHierarchy.Shapes;

public abstract class Shape
{
    internal string Name { get; }

    protected Shape(string name) => Name = name;

    internal virtual double CalculateArea() => 0.0;
}
