var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseWebAssemblyDebugging();
else
    app.UseExceptionHandler("/Error");

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.MapRazorPages();
app.MapFallbackToPage("/_Host");

app.Run();
