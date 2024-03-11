using BuildingAShapeHierarchy.Shapes;
namespace BuildingAShapeHierarchy;

public class Program
{
  public static void Main()
  {
    var circle = new Circle("My Circle", 5);
    var rectangle = new Rectangle("My Rectangle", 5, 10.3);
    var triangle = new Triangle("My Triangle", 5, 10.2);

    List<Shape> myShapes = new() { circle, rectangle, triangle };

    foreach (Shape shape in myShapes)
    {
      PrintShapeArea(shape);
    }
  }

  public static void PrintShapeArea(Shape shape)
  {
    Console.WriteLine($"Name of Shape: {shape.Name}");
    Console.WriteLine($"Area of Shape: {shape.CalculateArea()}");
  }
}
