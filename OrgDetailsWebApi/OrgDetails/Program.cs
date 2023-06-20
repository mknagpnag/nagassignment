using Microsoft.EntityFrameworkCore;
using OrgDetails;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var host = Environment.GetEnvironmentVariable("HOST") ?? "localhost";
var port = Environment.GetEnvironmentVariable("PORT") ?? "1433";
var password = Environment.GetEnvironmentVariable("SA_PASSWORD") ?? builder.Configuration.GetValue<string>("SA_PASSWORD");

var userid = builder.Configuration.GetValue<string>("SQL_USER");
var usersDataBase = builder.Configuration.GetValue<string>("SQL_DATABASE");

string connString = $"server=tcp:{host},{port}; User Id={userid};Password={password};Initial Catalog={usersDataBase};TrustServerCertificate=true";
builder.Services.AddDbContext<OrgDetailsContext>(o => o.UseSqlServer(connString));
//builder.Services.AddDbContext<OrgDetailsContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();


using (var serviceScope = app.Services.GetService<IServiceScopeFactory>().CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<OrgDetailsContext>();
    context.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
