using LibraryManager.Repository.Injections;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<LibraryManagerContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryManagerContext") ?? throw new InvalidOperationException("Connection string 'LibraryManagerContext' not found.")));

// Add services to the container.
builder.Services.AddPostgres(builder.Configuration);
builder.Services.AddRepositories();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
