using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Expense Manager API",
        Version = "v1",
        Description = "A personal finance management system that allows users to track their transactions, " +
                      "categorize expenses, assign beneficiaries, and associate purchases with stores. " +
                      "It supports multiple currencies, role-based permissions, and detailed reporting " +
                      "for better financial insights."
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Expense Manager API v1"));}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
