// Add services to the container.
using FluentAssertions.Common;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Globalization;
using System.Text.Json.Serialization;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;
using TheBakeryApp.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "TheBakeryApp", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter 'Bearer' followed by your JWT token.",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddHttpClient();
builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IVenda, VendaService>();
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbContext.Database.Migrate(); // Aplica as migrações no banco de dados
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Habilitar Swagger no desenvolvimento e produção
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TheBakeryApp v1");
    c.RoutePrefix = string.Empty; // Faz o Swagger estar disponível na raiz ('/')
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); // Mover para antes do app.UseRouting()
app.UseRouting();
app.UseAuthorization();

// Mapear Razor Pages e Endpoints
app.MapRazorPages();
app.MapControllers();

app.Run();