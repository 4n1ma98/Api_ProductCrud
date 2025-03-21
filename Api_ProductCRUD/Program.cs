using Business;
using Business.Contracts;
using DataAccess;
using DataAccess.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Configurar servicios de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials());
});
// Configurar servicios de CORS

builder.Services.AddControllers();

builder.Services.AddTransient<DBContext>();

builder.Services.AddScoped<IProductValidation, ProductValidation>();

builder.Services.AddScoped<IErrorCode, ErrorCode>();
builder.Services.AddScoped<IErrorLog, ErrorLog>();
builder.Services.AddScoped<IProductCrud, ProductCrud>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("AllowAngularApp");

app.MapControllers();

app.Run();
