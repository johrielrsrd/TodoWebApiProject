using Microsoft.EntityFrameworkCore;
using TodoWebApiProject.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "corspolicy", build =>
    {
        build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ToDoContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("corspolicy");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();