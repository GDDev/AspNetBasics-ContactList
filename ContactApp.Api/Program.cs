using ContactApp.Api.Repositories.Abstractions;
using ContactApp.Api.Repositories.InMemory;
using ContactApp.Api.Services;
using ContactApp.Api.Services.Interfaces;
using ContactApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddSingleton<IContactRepository, InMemoryContactRepository>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddSingleton<ICallRecordRepository, InMemoryCallRecordRepository>();
builder.Services.AddScoped<ICallImportService, CallImportService>();
builder.Services.AddScoped<ICallRecordService, CallRecordService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

if (app.Environment.IsDevelopment())
    app.UseHttpsRedirection();

app.UseForwardedHeaders();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Contacts}/{action=Index}/{id?}");
app.MapControllers();

// Docker health check endpoint
app.MapGet("/health", () => Results.Ok("OK"));

app.Run();
