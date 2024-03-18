namespace StudentMangementSystem.classes;

using System.Text.Json;

public class StudentList : GenericStudentList<Student>
{
  public override Student addStudent(Student student)
  {
    Students.Add(student);

    return student;
  }

  public override Student removeStudent(string id)
  {
    var student = Students.Find(s => s.GetId() == id);
    if (student == null)
    {
      throw new Exception("Student not found");
    }

    Students.Remove(student);
    return student;
  }

  public override Student searchById(string id)
  {
    var student = Students.Find(s => s.GetId() == id) ?? null;

    if (student != null)
    {
      return student;
    }
    else
    {
      throw new Exception("Student not found");
    }
  }

  public override List<Student> searchByName(string name)
  {
    return Students.Where(s => s.Name.Contains(name)).ToList();
  }

  public override Student updateStudent(string id, Student updatedStudent)
  {
    var student = Students.Find(s => s.GetId() == id);

    if (student != null)
    {
      student.Name = updatedStudent.Name;
      student.Age = updatedStudent.Age;
      student.Grade = updatedStudent.Grade;
    }
    else
    {
      throw new Exception("Student not found");
    }

    return student;
  }

  public static void PrintStudent(Student student)
  {
    Console.WriteLine($"Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}, ID: {student.GetId()}");
  }

  public static void PrintStudents(List<Student> students)
  {
    foreach (var student in students)
    {
      PrintStudent(student);
    }
  }

  public static List<Student> LoadStudents(String fileName)
  {
    String serializedStudents = File.ReadAllText(fileName);

    return JsonSerializer.Deserialize<List<Student>>(serializedStudents) ?? new();
  }

  public static void StoreStudents(String fileName, List<Student> students)
  {
    String serializedStudents = JsonSerializer.Serialize(students);
    Console.WriteLine(serializedStudents);

    File.WriteAllText(fileName, serializedStudents);
  }
}
