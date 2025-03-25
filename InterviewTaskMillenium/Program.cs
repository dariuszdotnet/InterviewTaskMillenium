var builder = WebApplication.CreateBuilder(args);

AddDIServices(builder);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

TurnOnSwagger(app);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddDIServices(WebApplicationBuilder builder)
{
    builder.Services.AddScoped<ICardService, CardService>();
    //builder.Services.AddScoped<IAllowedActionsService, AllowedActionsNaiveSubstraction>();
    builder.Services.AddScoped<IAllowedActionsService, AllowedActionsCoR>();
}

static void TurnOnSwagger(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
}