using ToDoApp.Models;

namespace ToDoApp.Repositories.Interfaces;

public interface IToDoListRepository
{
    List<ToDoList> ToDoList { get; }
}