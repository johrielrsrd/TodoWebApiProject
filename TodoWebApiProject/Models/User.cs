namespace TodoWebApiProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public ToDoItem? ToDoItem { get; set; } //one-to-one; reference navigation to document.
    }
}
