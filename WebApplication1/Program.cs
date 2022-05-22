
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var DataBaseType = builder.Configuration.GetValue<string>("DataBaseType");
if (DataBaseType == "sql")
{
    Repo.SQL.StartUp.ConfigureServices(builder.Services);
}
else if (DataBaseType == "mongoDb")
{
    Repo.MongoDb.StartUp.ConfigureServices(builder.Services);
}
else if (DataBaseType == "elastic")
{
    Repo.Elastic.StartUp.ConfigureServices(builder.Services);
}
else
    throw new Exception("valid DataBaseType => sql or mongoDb");


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
