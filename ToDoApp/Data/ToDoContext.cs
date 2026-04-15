using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Data;

public class ToDoContext : DbContext
{
    public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
    {

    }

    public DbSet<ToDoItem> ToDoItems { get; set; }

    //get all items 
    public Task<List<ToDoItem>> GetAllAsync()
    {
        var items = ToDoItems.AsQueryable().ToListAsync();
        return items;
    }

    //get item by id 
    public Task<ToDoItem> GetByIdAsync(int id)
    {
        var item = ToDoItems.Where(i => i.Id == id).FirstOrDefaultAsync();
        if (item == null)
            throw new Exception("Item not found");
        return item;
    }

    //add new item 
    public async Task AddAsync(ToDoItem item)
    {
        await ToDoItems.AddAsync(item);
        await base.SaveChangesAsync();
    }

    //update item 
    public async Task UpdateAsync(ToDoItem item)
    {
        ToDoItems.Update(item);
        await base.SaveChangesAsync();
    }

    //delete an item 
    public async Task<bool> DeleteAsync(int id)
    {
        var item = await ToDoItems.Where(i => i.Id == id).FirstOrDefaultAsync();
        if (item == null)
            return false;

        ToDoItems.Remove(item);
        await base.SaveChangesAsync();
        return true;
    }



}
