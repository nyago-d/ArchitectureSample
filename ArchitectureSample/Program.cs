using ArchitectureSample.Application.Create;
using ArchitectureSample.Application.Delete;
using ArchitectureSample.Application.Get;
using ArchitectureSample.Application.List;
using ArchitectureSample.Application.Update;
using ArchitectureSample.Domain.Todos;
using ArchitectureSample.Infrastructure.Todos;
using ArchitectureSample.Presentation.Create;
using ArchitectureSample.Presentation.Delete;
using ArchitectureSample.Presentation.Get;
using ArchitectureSample.Presentation.List;
using ArchitectureSample.Presentation.Update;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<ITodoQuery, TodoQuery>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoDao, TodoDao>();
builder.Services.AddScoped<TodoService>();

builder.Services.AddScoped<ListInputAdapter>();
builder.Services.AddScoped<ListUseCase>();
builder.Services.AddScoped<ListPresenter>();

builder.Services.AddScoped<GetInputAdapter>();
builder.Services.AddScoped<GetUseCase>();
builder.Services.AddScoped<GetPresenter>();

builder.Services.AddScoped<CreateInputAdapter>();
builder.Services.AddScoped<CreateUseCase>();
builder.Services.AddScoped<CreatePresenter>();

builder.Services.AddScoped<UpdateInputAdapter>();
builder.Services.AddScoped<UpdateUseCase>();

builder.Services.AddScoped<DeleteInputAdapter>();
builder.Services.AddScoped<DeleteUseCase>();

var app = builder.Build();

app.MapControllers();

app.Run();
