using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<IEnumerable<ToDo>> GetToDoItems()
        {
            return _dataContext.ToDoTable.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<ToDo> GetToDoItem(int id)
        {
            var existingToDoItem = _dataContext.ToDoTable.Find(id);

            return existingToDoItem == null ? NotFound() : existingToDoItem; //conventional? or better to use if statement for better readability?
        }

        [HttpPost]
        public ActionResult<ToDo> PostToDoItem(ToDo todoItem)
        {
            _dataContext.ToDoTable.Add(todoItem);
            _dataContext.SaveChanges();

            return CreatedAtAction(nameof(GetToDoItems), new { id = todoItem.Id }, todoItem); //can use "NoContent()" return? but this is the conventional way?
        }

        [HttpPut("{id}")]
        public ActionResult<ToDo> PutToDoItem(int id, ToDo newToDoItem)
        {
            //_dataContext.Entry(newToDoItem).State = EntityState.Modified;

            var existingToDoItem = _dataContext.ToDoTable.Find(id);

            if (existingToDoItem == null)
            {
                return NotFound();
            }

            existingToDoItem.Text = newToDoItem.Text;
            existingToDoItem.IsComplete = newToDoItem.IsComplete;

            _dataContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ToDo> DeleteToDoItem(int id)
        {
            var removeItem = _dataContext.ToDoTable.Find(id);

            if (removeItem == null)
            {
                return NotFound();
            }

            _dataContext.ToDoTable.Remove(removeItem);
            _dataContext.SaveChanges();

            return NoContent();
        }
    }
}