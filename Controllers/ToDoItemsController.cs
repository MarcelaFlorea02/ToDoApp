using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : ControllerBase
    {
        private readonly ToDoAppContext _doContext;

        //dependency injection 
        public ToDoItemsController(ToDoAppContext toDoAppContext)
        {
            _doContext = toDoAppContext;
        }

        //get all items 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            if (_doContext == null)
                return NotFound();
            return await _doContext.Items.ToListAsync();
        }

        // get an item 
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItem(int id)
        {
            if (_doContext == null)
                return NotFound();


            var item = await _doContext.Items.FindAsync(id);

            //LINQ 
            // _doContext.Items.Where(i => i.Id == id).First();
            // _doContext.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }

        //add an item 
        [HttpPost]
        public async Task<ActionResult<ToDoItem>> PostToDoItem(ToDoItem item)
        {
            if (_doContext == null)
                return NotFound();
            if (_doContext.Items == null)
                return NotFound();

            _doContext.Items.Add(item);
            await _doContext.SaveChangesAsync();

            return Ok();
        }

        //update an item 
        [HttpPut("{id}")]
        public async Task<ActionResult<ToDoItem>> UpdateToDoItem(int id, ToDoItem item)
        {
            if (id != item.Id)
                return BadRequest();

            _doContext.Entry(item).State = EntityState.Modified;

            //   _doContext.Items.Update(item); 
            try
            {
                await _doContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();

        }

        //delete an item
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteToDoItem(int id)
        {

            if (_doContext == null)
                return NotFound();

            var item = _doContext.Items.First(i => i.Id == id);
            if (item == null)
                return NotFound();

            _doContext.Items.Remove(item);

            await _doContext.SaveChangesAsync();

            return Ok();

        }

    }
}
