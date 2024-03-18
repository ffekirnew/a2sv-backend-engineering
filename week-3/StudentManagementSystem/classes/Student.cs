namespace StudentMangementSystem.classes;

public class Student
{
  public string Name { get; set; } = "";
  public int Age { get; set; }
  private readonly string id;
  public double Grade { get; set; }

  public Student(string name, int age, double grade, string id)
  {
    Name = name;
    Age = age;
    Grade = grade;
    this.id = id;
  }

  public string GetId()
  {
    return id;
  }
}
