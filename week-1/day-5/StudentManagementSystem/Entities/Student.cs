namespace StudentManagementSystem.Entities;

class Student
{
    private string? name;
    private int? age;
    private string? id;
    private float cgpa = 0;
    private string? department;
    private readonly int rollNumber;
    private List<Course> courses = new List<Course>();

    public string? Name { get { return name; } init { name = value; } }
    public string? Id { get { return id; } init { id = value; } }
    public float CGPA { get { return cgpa; } init { cgpa = value; } }
    public int? Age { get { return age; } init { age = value; } }
    public string? Department { get { return department; } init { department = value; } }
    public List<Course> Courses { get { return courses; } init { courses = value; } }
    public int RollNumber {get => rollNumber; init => rollNumber = value;}

    public Student()
    { }

    public void AddCourseGrade(Course course)
    {
        cgpa = cgpa * courses.Count + course.Grade;
        courses.Add(course);
        cgpa /= courses.Count;
    }

    public override string ToString() => $"{rollNumber, -1} {name, -18} {age, -5} {id, -15} {department, -20} {cgpa, -5}";
    
}
