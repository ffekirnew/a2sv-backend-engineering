using System.Text.Json;
using StudentManagementSystem.Entities;
using StudentManagementSystem.Serializers;

namespace StudentManagementSystem.UseCases;


class StudentListManager
{
    private readonly StudentList<Student> studentList = new();
    public int NumberOfStudents {get => studentList.NumberOfStudents;}

    public void AddStudent(string name, int age, string id, string department)
    {
        Student student = new() { Name = name, Age = age, Id = id, Department = department, RollNumber = NumberOfStudents + 1 };
        studentList.Add(student);
    }

    public void RemoveStudent(int index)
    {
        studentList.Remove(studentList.List[index - 1]);
    }

    public void AddCourseGrade(int studentIndex, string courseName, float courseGrade)
    {
        Course course = new(){ Name = courseName, Grade = courseGrade };
        studentList.List[studentIndex - 1].AddCourseGrade(course);
    }

    public StudentList<Student> Search(string query)
    {
        if (string.IsNullOrEmpty(query))
            return studentList;

        query = query.ToLower(); // Convert query to lowercase for case-insensitive search.

        IEnumerable<Student> searchResults = studentList.List
            .Where(student =>
                student.Name!.ToLower().Contains(query) ||
                student.Department!.ToLower().Contains(query) ||
                student.Id!.ToLower().Contains(query)
            );

        // Create a new instance of StudentList<T> using the search results.
        StudentList<Student> resultsList = new();
        foreach (Student student in searchResults)
        {
            resultsList.Add(student);
        }
        
        return resultsList;
    }

    public StudentList<Student> FilterByGrade(float cutOff)
    {
        IEnumerable<Student> searchResults = studentList.List
            .Where(student => student.CGPA >= cutOff);
        
        StudentList<Student> resultsList = new();
        foreach (Student student in searchResults)
        {
            resultsList.Add(student);
        }

        return resultsList;
    }

    public async Task ReadFromJson()
    {
        studentList.List = await Serializer<Student>.FromJson("students.json");
    }

    public async Task WriteToJson()
    {
        await Serializer<Student>.ToJson(studentList.List, "students.json");
    }


}
