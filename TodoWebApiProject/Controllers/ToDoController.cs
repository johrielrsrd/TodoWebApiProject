using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebApiProject.Data;
using TodoWebApiProject.Models;

namespace TodoWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _dataContext;

        public ToDoController(ToDoContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItems()
        {
            return _dataContext.ToDoItems.ToList();
        }

        [HttpGet("{todoitemid}")]
        public ActionResult<IEnumerable<ToDoItem>> GetToDoItem(int todoitemid)
        {
            var existingToDoItem = _dataContext.ToDoItems.Where(e => e.ToDoItemId == todoitemid).ToList();

            return existingToDoItem == null ? NotFound() : existingToDoItem; //conventional? or better to use if statement for better readability?
        }

        [HttpPost]
        public ActionResult<ToDoItem> PostToDoItem(ToDoItem todoItem)
        {
            _dataContext.ToDoItems.Add(todoItem);
            _dataContext.SaveChanges();

            return CreatedAtAction(nameof(GetToDoItems), new { id = todoItem.Id }, todoItem); //can use "NoContent()" return? but this is the conventional way?
        }

        [HttpPut("{id}")]
        public ActionResult<ToDoItem> PutToDoItem(int id, ToDoItem newToDoItem)
        {
            if (id != newToDoItem.Id)
            {
                return BadRequest();
            }
            _dataContext.Entry(newToDoItem).State = EntityState.Modified;

            _dataContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ToDoItem> DeleteToDoItem(int id)
        {
            var removeItem = _dataContext.ToDoItems.Find(id);

            if (removeItem == null)
            {
                return NotFound();
            }

            _dataContext.ToDoItems.Remove(removeItem);
            _dataContext.SaveChanges();

            return NoContent();
        }
    }
}