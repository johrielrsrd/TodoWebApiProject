using Microsoft.EntityFrameworkCore;
using TodoWebApiProject.Models;

namespace TodoWebApiProject.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {

        }

        public DbSet<ToDo>ToDoTable { get; set; }
    }
}
