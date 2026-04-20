namespace ToDoApp.ModelsDTO;

public class AddToDoItem
{
    public string Description { get; set; }
    public bool IsDone { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
