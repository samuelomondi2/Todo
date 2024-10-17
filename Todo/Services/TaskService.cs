using Todo.Models;

namespace Todo.Services;

public class TaskService: ITaskService
{
    private static readonly List<Tasks> AllTasks = new();
    public Task CreateTask(Tasks task)
    {
        AllTasks.Add(task);
        return Task.CompletedTask;
    }
    public Task<Tasks?> UpdateTask(int id, Tasks tasks)
    {
        var task = AllTasks.FirstOrDefault(x => x.Id == id);
        if(task != null)
        {
            task.TaskName = tasks.TaskName;
            task.TaskPriority = tasks.TaskPriority;
            task.TaskDeadline = tasks.TaskDeadline;
            task.TaskStatus = tasks.TaskStatus;
            task.TaskAssignees = tasks.TaskAssignees;
            task.TaskDetails = tasks.TaskDetails;
        }
        return Task.FromResult(task);
    }
    public Task<Tasks?> GetTask(int id)
    {
        return Task.FromResult(AllTasks.FirstOrDefault(x => x.Id == id));
    }
    public Task<List<Tasks?>> GetAllTasks()
    {
        return Task.FromResult(AllTasks);
    }
    public Task DeleteTask(int id)
    {
        var task = AllTasks.FirstOrDefault(x => x.Id == id);
        if(task != null)
        {
            AllTasks.Remove(task);
        }
        return Task.CompletedTask;
    }
}