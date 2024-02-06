namespace TodoWebApiProject.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string? Text { get; set; }
        public bool IsComplete { get; set; }
        public int ToDoItemId { get; set; } //required foreign key props.
        public User User { get; set; } = null!;  //required reference navigation to parent.
    }
}
