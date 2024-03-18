namespace StudentMangementSystem;

using StudentMangementSystem.classes;

public class Program
{
  public static StudentList studentList = new();

  public static void Main(String[] args)
  {
    var exitCode = 0;
    while (exitCode == 0)
    {
      exitCode = RunCtl();
    }
  }

  private static int RunCtl()
  {
    Console.WriteLine("Welcome to Student Management System!");
    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. Add a student");
    Console.WriteLine("2. Remove a student");
    Console.WriteLine("3. Update a student");
    Console.WriteLine("4. Search for a student by name");
    Console.WriteLine("5. Search for a student by ID");
    Console.WriteLine("6. Print all students");
    Console.WriteLine("7. Store to file");
    Console.WriteLine("8. Load from file");
    Console.WriteLine("Press any other key to exit.");

    var option = Console.ReadLine();
    switch (option)
    {
      case "1":
        AddStudent();
        return 0;
      case "2":
        RemoveStudent();
        return 0;
      case "3":
        UpdateStudent();
        return 0;
      case "4":
        SearchByName();
        return 0;
      case "5":
        SearchById();
        return 0;
      case "6":
        PrintAllStudents();
        return 0;
      case "7":
        StoreToFile();
        return 0;
      case "8":
        LoadFromFile();
        return 0;
      default:
        return 1;
    }
  }

  private static void AddStudent()
  {
    Console.WriteLine("Enter student name:");
    var name = Console.ReadLine() ?? "";
    Console.WriteLine("Enter student age:");
    var age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter student grade:");
    var grade = Convert.ToDouble(Console.ReadLine());
    Console.WriteLine("Enter student ID:");
    var id = Console.ReadLine() ?? "";

    var student = new Student(name, age, grade, id);
    studentList.addStudent(student);
  }

  private static void RemoveStudent()
  {
    Console.WriteLine("Enter student ID:");
    var id = Console.ReadLine() ?? "";
    studentList.removeStudent(id);
  }

  private static void UpdateStudent()
  {
    Console.WriteLine("Enter student ID:");
    var id = Console.ReadLine() ?? "";
    Console.WriteLine("Enter student name:");
    var name = Console.ReadLine() ?? "";
    Console.WriteLine("Enter student age:");
    var age = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter student grade:");
    var grade = Convert.ToDouble(Console.ReadLine());

    var student = new Student(name, age, grade, id);
    studentList.updateStudent(id, student);
  }

  private static void SearchByName()
  {
    Console.WriteLine("Enter student name:");
    var name = Console.ReadLine() ?? "";
    var students = studentList.searchByName(name);
    foreach (var student in students)
    {
      StudentList.PrintStudent(student);
    }
  }

  private static void SearchById()
  {
    Console.WriteLine("Enter student ID:");
    var id = Console.ReadLine() ?? "";
    var student = studentList.searchById(id);
    StudentList.PrintStudent(student);
  }

  private static void PrintAllStudents()
  {
    var students = studentList.Students;
    StudentList.PrintStudents(students);
  }

  private static void StoreToFile()
  {
    StudentList.StoreStudents("students.json", studentList.Students);
  }

  private static void LoadFromFile()
  {
    studentList.Students = StudentList.LoadStudents("students.json");
  }
}
