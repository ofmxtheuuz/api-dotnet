using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Repositories.Interfaces;

namespace ToDoApp.Repositories;

public class ToDoListRepository : IToDoListRepository
{
    private readonly AppDbContext _context;

    public ToDoListRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<ToDoList> ToDoList => _context.ToDoList.ToList();
}