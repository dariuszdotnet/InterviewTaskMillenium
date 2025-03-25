var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

TurnOnSwagger(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void TurnOnSwagger(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}