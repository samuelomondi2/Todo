namespace Todo.Models;
public class Tasks
{
    public int? Id { get; set; }
    public string? TaskName { get; set; }
    public string? TaskPriority { get; set; }
    public string? TaskDeadline { get; set; }
    public string? TaskStatus { get; set; }
    public string? TaskAssignees { get; set; }
    public string? TaskDetails { get; set; }
    public DateTime? TimeStamp { get; set; }
}