using SkillUP.API.Extensions;
using SkillUP.Application;
using SkillUP.Persistence;
using SkillUP.Shared;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.


builder.Services.AddApplicationLayer();
builder.Services.AddSharedInfrastructure();
builder.Services.AddRepositories(configuration);


builder.Services.AddControllers();
builder.Services.AddAppVersion();
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

//app.UseAuthorization();
app.UseErrorHandlerMidleware();

app.MapControllers();

app.Run();
