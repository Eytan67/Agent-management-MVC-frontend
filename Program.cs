using Agent_management_MVC_frontend.Models;
using Agent_management_MVC_frontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();

builder.Services.AddScoped<MissionsService>();
builder.Services.AddScoped<GeneralService>();
builder.Services.AddHttpClient<AgentService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=General}/{action=Index}/{id?}");

app.Run();
