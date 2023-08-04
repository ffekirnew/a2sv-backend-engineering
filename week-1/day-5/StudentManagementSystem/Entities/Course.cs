namespace StudentManagementSystem.Entities;

public record Course {
    public string? Name { get; init; }
    public float Grade { get; init; } = 0;

    public Course()
    {
    }
}