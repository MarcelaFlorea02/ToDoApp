using Microsoft.EntityFrameworkCore;

namespace ToDoApp.Models
{
    public class ToDoAppContext : DbContext
    {
        public ToDoAppContext(DbContextOptions<ToDoAppContext> options) : base(options) { }

        public DbSet<ToDoItem> Items { get; set; }
    }
}
