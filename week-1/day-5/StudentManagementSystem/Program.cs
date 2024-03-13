using StudentManagementSystem.Entities;
using StudentManagementSystem.UseCases;

namespace StudentManagementSystem;

class Program
{
  private readonly StudentListManager studentListManager = new();

  public static async Task Main()
  {
    var app = new Program();
    await app.Initialize();
    await app.Run();
  }

  private static int PrintMenu()
  {
    Console.WriteLine();
    Console.WriteLine("".PadRight(70, '`'));
    Console.WriteLine("Welcome to Student Management System");
    Console.WriteLine("".PadRight(70, '`'));
    Console.WriteLine("Please select an option from the menu below:");
    Console.WriteLine("1. Add Student");
    Console.WriteLine("2. Remove Student");
    Console.WriteLine("3. Search Student");
    Console.WriteLine("4. Filter Students by Grade");
    Console.WriteLine("5. Print Student List");
    Console.WriteLine("6. Add a Grade for Student");
    Console.WriteLine("7. Save Student List");
    Console.WriteLine("8. Load Student List");
    Console.WriteLine("9. Exit");
    Console.WriteLine("".PadRight(70, '`'));
    Console.WriteLine();

    return 9;
  }

  private async Task Initialize()
  {
    await studentListManager.ReadFromJson();
  }

  private async Task Run()
  {
    var length = PrintMenu();
    int option = ReadNumber("Enter your option: ", 1, length);
    Console.WriteLine();

    Dictionary<int, Action> options =
        new()
        {
                { 1, AddStudent },
                { 2, RemoveStudent },
                { 3, SearchStudent },
                { 4, FilterByGrade },
                { 5, PrintAllStudents },
                { 6, AddStudentGrade }
        };

    Dictionary<int, Func<Task>> asyncOptions =
        new() { { 7, SaveToFile }, { 8, LoadFromFile }, };

    if (options.ContainsKey(option))
      options[option]();
    else if (asyncOptions.ContainsKey(option))
      await asyncOptions[option]();
    else
    {
      await Exit();
      return;
    }

    await Run();
  }

  private void AddStudentGrade()
  {
    if (studentListManager.NumberOfStudents == 0)
    {
      Console.WriteLine(
          "There are no students to add grades to. Try adding some students first."
      );
      return;
    }

    PrintAllStudents();
    int studentIndex = ReadNumber(
        "Enter the student index: ",
        1,
        studentListManager.NumberOfStudents
    );
    string courseName = ReadString("Enter the course name: ");
    float courseGrade = ReadNumber("Enter the course grade: ", 0, 4);
    studentListManager.AddCourseGrade(studentIndex, courseName, courseGrade);
  }

  private async Task Exit()
  {
    await studentListManager.WriteToJson();
    Console.WriteLine("Exiting the program. Goodbye!");
  }

  private async Task LoadFromFile()
  {
    await studentListManager.ReadFromJson();
    Console.WriteLine("Loaded changes from file.");
  }

  private async Task SaveToFile()
  {
    await studentListManager.WriteToJson();
    Console.WriteLine("Saved changes to file.");
  }

  private void PrintAllStudents()
  {
    StudentList<Student> students = studentListManager.Search("");
    if (students.NumberOfStudents == 0)
    {
      Console.WriteLine("There are no students to print. Try adding some students first.");
      return;
    }
    Console.WriteLine("Here are all the students:");
    students.Print();
  }

  private void FilterByGrade()
  {
    if (studentListManager.NumberOfStudents == 0)
    {
      Console.WriteLine("There are no students to filter. Try adding some students first.");
      return;
    }
    int grade = ReadNumber("Enter the grade to filter by: ", 0, 100);
    StudentList<Student> students = studentListManager.FilterByGrade(grade);
    if (students.NumberOfStudents == 0)
    {
      Console.WriteLine("No students found for that grade.");
      return;
    }
    Console.WriteLine("Here are students that matched the grade:");
    students.Print();
  }

  private void SearchStudent()
  {
    string searchQuery = ReadString("Enter the search query: ", true);
    StudentList<Student> students = studentListManager.Search(searchQuery);
    if (students.NumberOfStudents == 0)
    {
      Console.WriteLine("No students found for that search query.");
      return;
    }
    Console.WriteLine("Here are students that matched the query:");
    students.Print();
  }

  private void RemoveStudent()
  {
    if (studentListManager.NumberOfStudents == 0)
    {
      Console.WriteLine("There are no students to remove. Try adding some students first.");
      return;
    }
    // Print the students list.
    StudentList<Student> students = studentListManager.Search("");
    Console.WriteLine("Please select a student to remove:");
    PrintAllStudents();

    // Read the student index to remove.
    int index = ReadNumber("Enter the student index to remove: ", 1, students.NumberOfStudents);
    studentListManager.RemoveStudent(index);
  }

  private void AddStudent()
  {
    string name = ReadString("Enter student name: ");
    int age = ReadNumber("Enter student age: ", 0, 100);
    string id = ReadString("Enter student ID: ");
    string department = ReadString("Enter student department: ");

    studentListManager.AddStudent(name, age, id, department);
  }

  // Helper Methods
  private static string ReadString(string prompt, bool canBeEmpty = false)
  {
    Console.Write(prompt);
    string? response = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(response) && !canBeEmpty)
    {
      Console.WriteLine("Please enter a valid response. It cannot be empty.");
      Console.Write(prompt);
      response = Console.ReadLine();
    }

    return response ?? "";
  }

  private static int ReadNumber(string prompt, int min, int max)
  {
    Console.Write(prompt);
    string? response = Console.ReadLine();
    int result;
    while (!int.TryParse(response, out result) || result < min || result > max)
    {
      Console.WriteLine("Please enter a valid response from the option range.");
      Console.Write(prompt);
      response = Console.ReadLine();
    }

    return result;
  }
}
