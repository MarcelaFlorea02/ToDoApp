namespace ToDoApp.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDone { get; set; }
}
