using Microsoft.AspNetCore.Mvc;
using TodoWebApiProject.Data;
using TodoWebApiProject.Models;

namespace TodoWebApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public ToDoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDo>> Get()
        {
            return _dataContext.ToDos.ToList();
        }
    }
}
