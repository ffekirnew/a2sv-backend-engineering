namespace BuildingAShapeHierarchy.Shapes;

class Triangle : Shape
{
  private double Base;
  private double Height;


  internal Triangle(string name, double baseLength, double height) : base(name) => (Base, Height) = (baseLength, height);

  internal override double CalculateArea() => (Base * Height) / 2;
}
