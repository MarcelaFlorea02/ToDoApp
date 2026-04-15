using Microsoft.AspNetCore.Mvc;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController : ControllerBase
{
    public readonly ToDoContext _context;

    public ToDoController(ToDoContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<ToDoItem>>> Get()
    {
        var items = await _context.GetAllAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ToDoItem>> GetById(int id)
    {
        var item = await _context.GetByIdAsync(id);
        if (item == null)
            return NotFound();

        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult> Post(ToDoItem item)
    {
        await _context.AddAsync(item);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, ToDoItem item)
    {
        if (id != item.Id)
            return BadRequest();

        var toDoItem = await _context.GetByIdAsync(id);
        if (toDoItem == null)
            return NotFound(); 

        await _context.UpdateAsync(toDoItem);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await _context.DeleteAsync(id);
        if(!deleted)
            return BadRequest();

        return Ok();
    }

}
