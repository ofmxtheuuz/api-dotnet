namespace ToDoApp.Models;

public class ToDoList
{
    public int Id { get; set; }
    public string Content { get; set; }
    public bool Completed { get; set; }
    public DateTime SendDate { get; set; }
}