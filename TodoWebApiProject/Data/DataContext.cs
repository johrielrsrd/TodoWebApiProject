using Microsoft.EntityFrameworkCore;
using TodoWebApiProject.Models;

namespace TodoWebApiProject.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<ToDo>toDos { get; set; }
    }
}
