using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Models;
using ToDoApp.Repositories.Interfaces;
using ToDoApp.Requests;

namespace ToDoApp.Controllers;

[ApiController]
public class ToDoController : ControllerBase
{
    private readonly IToDoListRepository _toDoListRepository;
    private readonly AppDbContext _context;

    public ToDoController(IToDoListRepository toDoListRepository, AppDbContext context)
    {
        _toDoListRepository = toDoListRepository;
        _context = context;
    }

    [Route("/see")]
    public async Task<ActionResult<List<ToDoList>>> See()
    {
        return _toDoListRepository.ToDoList;
    }

    [Route("/see/{id:int}")]
    public async Task<ActionResult<ToDoList>> SeeDetails(int id)
    {
        return _toDoListRepository.ToDoList.FirstOrDefault(t => t.Id == id);
    }

    [Route("/completed/{id:int}")]
    [HttpPut]
    public async Task<ActionResult<ToDoList>> Completed(int id)
    {
        _context.ToDoList.FirstOrDefault(t => t.Id == id).Completed = true;
        _context.SaveChanges();
        return _toDoListRepository.ToDoList.FirstOrDefault(x => x.Id == id);
    }
    
    [Route("/add")]
    [HttpPost]
    //
    public async Task<ActionResult<ToDoList>> Add([FromBody] CreateRequest request)
    {
        _context.ToDoList.Add(new ToDoList()
        {
            Completed = request.Completed,
            Content = request.Content,
            SendDate = DateTime.Now
        });
        _context.SaveChanges();
        return _context.ToDoList.FirstOrDefault(t => t.Content == request.Content);
    }
    
    [Route("delete/{id:int}")]
    [HttpDelete]
    public async Task<ActionResult<List<ToDoList>>> Delete(int id)
    {
        _context.ToDoList.Remove(_context.ToDoList.FirstOrDefault(t => t.Id == id));
        _context.SaveChanges();
        return _toDoListRepository.ToDoList;
    }
    
    
}
