using Note.API.Middleware;
using Note.Infrastructure.Dependency_Injection;
using Note.Application.Dependency_Injection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper();
builder.Services.AddNotepadRepository();
builder.Services.AddData(builder.Configuration.GetConnectionString("DataBaseConnectionString"));
builder.Services.AddMediatR();
builder.Services.AddValidator();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
