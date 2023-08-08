namespace StudentManagementSystem.Entities;

class StudentList<T>
{
    private List<T> students = new();
    public int NumberOfStudents
    {
        get => students.Count;
    }
    public List<T> List
    {
        get => students;
        set => students = value;
    }

    public void Add(T student)
    {
        Add(student, students);
    }

    public void Add(T student, List<T> students)
    {
        students.Add(student);
    }

    public void Remove(T student)
    {
        students.Remove(student);
    }

    public void Print()
    {
        Console.WriteLine("".PadRight(70, '-'));
        Console.WriteLine(
            $"  {"Name", -18} {"Age", -5} {"Id", -15} {"Department", -20} {"CGPA", -4}"
        );
        // Underline
        Console.WriteLine(
            $"  {"----", -18} {"---", -5} {"--", -15} {"----------", -20} {"----", -4}"
        );
        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
        // Create a divider
        Console.WriteLine("".PadRight(70, '-'));
    }

    public void Print(int index)
    {
        Console.WriteLine(students[index]);
    }

    public override string ToString() =>
        $"Student List Object with ${NumberOfStudents} number of students.";
}
