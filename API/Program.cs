using Application.Tasks.Commands.CreateTask;
using Application.Tasks.Queries.GetAllTasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Infrastucture.Mongo;
using Microsoft.Extensions.Configuration;
using Application.Behaviors;
using Application.Tasks.Commands.UpdateTask;
using Application.Tasks.Commands.DeleteTask;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMongoInfrastructure(builder.Configuration);

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateTaskCommand).Assembly);
});

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(PerformanceBehavior<,>));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.MapPost("/tasks", async (CreateTaskCommand cmd, IMediator mediator)
    => Results.Ok(await mediator.Send(cmd)));

app.MapGet("/tasks", async (IMediator mediator)
    => Results.Ok(await mediator.Send(new GetAllTasksQuery())));


app.MapPut("/tasks/{id}/status", async (string id, bool completed, IMediator mediator) =>
{
    var result = await mediator.Send(new UpdateTaskCommand(id, completed));
    return result ? Results.NoContent() : Results.NotFound();
});
app.MapDelete("/tasks/{id}", async (string id, IMediator mediator) =>
{
    var result = await mediator.Send(new DeleteTaskCommand(id));
    return result ? Results.NoContent() : Results.NotFound();
});

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
