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
                .HasOne(e => e.ToDoItem)
                .WithOne(e => e.User)
                .HasForeignKey<ToDoItem>(e => e.ToDoItemId)
                .IsRequired();
        }

    }
}
