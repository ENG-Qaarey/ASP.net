using FRST_project.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var users = new List<User>
{
    new User(1, "muscab", "muscab@example.com"),
    new User(2, "isma", "isma@example.com"),
    new User(3, "abdulahi", "abdulahi@example.com")
};

builder.Services.AddSingleton<IReadOnlyList<User>>(users);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapGet("/hello", () => "welcome to our API app");

app.MapPost("/hello", async (HttpContext context) =>
{
    Console.WriteLine(context.Request.Method);
    await context.Response.WriteAsync("hello post received");
});

// to test some api
app.MapGet("/api/data", () => new { Name = "muscab axmed", Age = 20 });

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
