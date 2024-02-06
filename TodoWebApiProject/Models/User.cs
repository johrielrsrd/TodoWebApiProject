namespace TodoWebApiProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Password { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; } = new List<ToDoItem>();
    }
}
