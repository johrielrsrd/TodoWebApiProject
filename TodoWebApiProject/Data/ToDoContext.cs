using Microsoft.EntityFrameworkCore;
using TodoWebApiProject.Models;

namespace TodoWebApiProject.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options)
        {
        }

        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.ToDoItems)
                .WithOne()
                .HasForeignKey(e => e.ToDoItemId)
                .IsRequired();
        }

    }
}
