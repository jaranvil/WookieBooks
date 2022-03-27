using Microsoft.EntityFrameworkCore;
using WookieBooks.Interfaces;
using WookieBooks.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WookieContext>(opt => opt.UseInMemoryDatabase("Books"));
builder.Services.Add(new ServiceDescriptor(typeof(IBookRepository), new BookRepository()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

