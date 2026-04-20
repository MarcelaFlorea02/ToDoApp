namespace ToDoApp.ModelsDTO
{
    public class UpdateToDoItem
    {
        public string Description { get; set; } 
        public bool IsDone { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow; 
    }
}
