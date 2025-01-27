using LibraryManager.Application.Commands.BookCommands.InsertBook;
using LibraryManager.Application.Repositories;
using LibraryManager.Core.Repositories;
using LibraryManager.Infrastructure.Persistence;
using LibraryManager.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryManagerDbContext>(options =>
    options.UseInMemoryDatabase("library_manager"));

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblyContaining<InsertBookCommand>());

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

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
