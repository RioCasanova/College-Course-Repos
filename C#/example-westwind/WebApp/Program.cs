using WestWindSystem;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Set up the connection string service for the application
// 1) Retrieve the connection string information from your appsettings.json
var connectionString = builder.Configuration.GetConnectionString("WWDB");


// 2) Register any service you wish to use
// in our solution our servie will be creatged (coded) in the class library WestWindSystem
// One of these serbives will be the setup of the database context connection.
// Another service will be created as the application requires


// This setup can be done here locally or this setup can be done elsewherem, and called from this location *****
// This means we can hardcode or we can have another class library that we can call from here and use its properties


builder.Services.WWBackendDependencies(options => options.UseSqlServer(connectionString));

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
