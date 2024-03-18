namespace StudentMangementSystem.classes;

public abstract class GenericStudentList<T>
{
  public List<T> Students { get; set; } = new();

  public abstract T addStudent(T student);
  public abstract T removeStudent(String id);
  public abstract T updateStudent(String id, T updatedStudent);
  public abstract List<T> searchByName(String name);
  public abstract T searchById(String id);
}
