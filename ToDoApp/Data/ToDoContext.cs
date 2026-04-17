using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {

    }

    // Initialize to satisfy the compiler; EF will populate this at runtime
    public DbSet<ToDoItem> ToDoItem { get; set; } = null!;


    //get all items 
    public Task<List<ToDoItem>> GetAllAsync()
    {
        return ToDoItem.ToListAsync();
    }

    //get item by id 
    public async Task<ToDoItem?> GetByIdAsync(int id)
    {
        var item = await ToDoItem.Where(i => i.Id == id).FirstOrDefaultAsync();
        return item;
    }

    //add new item 
    public async Task AddAsync(ToDoItem item)
    {
        await ToDoItem.AddAsync(item);
        await base.SaveChangesAsync();
    }

    //update item 
    public async Task UpdateAsync(ToDoItem item)
    {
        ToDoItem.Update(item);
        await base.SaveChangesAsync();
    }

    //delete an item 
    public async Task<bool> DeleteAsync(int id)
    {
        var item = await ToDoItem.Where(i => i.Id == id).FirstOrDefaultAsync();
        if (item == null)
            return false;

        ToDoItem.Remove(item);
        await base.SaveChangesAsync();
        return true;
    }



}
