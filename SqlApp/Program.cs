using SqlApp.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddMvc();
builder.Services.AddTransient<CourseService>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
