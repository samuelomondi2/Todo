using Todo.Models;

namespace Todo.Services;

public interface ITaskService
{
    Task CreateTask(Tasks task);
    Task<Tasks?> UpdateTask(int id, Tasks task);
    Task<Tasks?> GetTask(int id);
    Task<List<Tasks>> GetAllTasks();
    Task DeleteTask(int id);
}