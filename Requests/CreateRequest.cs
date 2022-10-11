namespace ToDoApp.Requests;

public class CreateRequest
{
    public string Content { get; set; }
    public bool Completed { get; set; }
}