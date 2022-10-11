using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<ToDoList> ToDoList { get; set; }
}