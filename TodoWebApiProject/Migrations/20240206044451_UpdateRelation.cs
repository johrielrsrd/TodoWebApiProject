using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoWebApiProject.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ToDoItemId",
                table: "ToDoItems");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoItemId",
                table: "ToDoItems",
                column: "ToDoItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ToDoItems_ToDoItemId",
                table: "ToDoItems");

            migrationBuilder.CreateIndex(
                name: "IX_ToDoItems_ToDoItemId",
                table: "ToDoItems",
                column: "ToDoItemId",
                unique: true);
        }
    }
}
