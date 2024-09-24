// Add services to the container.
using FluentAssertions.Common;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using TheBakeryApp.Infrastructure;
using TheBakeryApp.Interfaces;
using TheBakeryApp.Model;
using TheBakeryApp.Services;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddMvc().AddSessionStateTempDataProvider();
builder.Services.AddSession();
builder.Services.AddScoped<IProduto, ProdutoService>();
builder.Services.AddScoped<ICliente, ClienteService>();
builder.Services.AddScoped<IVenda, VendaService>();
builder.Services.AddDbContext<AppDBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDBContext>();
    dbContext.Database.Migrate(); // Aplica as migra  es no banco de dados
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();  // Mova para antes do app.UseRouting()
app.UseRouting();
//app.UseAuthentication();
app.UseAuthorization();

// Mapear Razor Pages e Endpoints
app.MapRazorPages();
app.MapControllers();

app.Run();

