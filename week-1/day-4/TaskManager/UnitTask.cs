using TaskManager.Commons.Enums;
namespace TaskManager;

class UnitTask
{
  public string? Name { get; set; }
  public string? Description { get; set; }
  public UnitTaskEnum Category { get; init; }
  public bool IsCompleted { get; set; }

  public UnitTask()
  { }

  public override string ToString() => $"Name: ({Name}) Description: ({Description}) Category: ({Category}) IsCompleted: ({IsCompleted})";

  public string ToCSV() => $"{Name},{Description},{(int)Category},{IsCompleted}";

}
