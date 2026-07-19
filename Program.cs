using EnglishApp.Components;
using EnglishApp.Services;

var builder = WebApplication.CreateBuilder(args);

// רישום השירותים של האפליקציה (Dependency Injection)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<GameService>();
builder.Services.AddSingleton<PictureService>();

var app = builder.Build();

// הגדרת צינור הבקשות (HTTP Request Pipeline)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

// ---- התיקון המרכזי כאן ----

// 1. מאפשר גישה רגילה לכל הקבצים ב-wwwroot (בשביל משחק הזיכרון, התמונות והצבעים)
app.UseStaticFiles();

// 2. הגדרה נקודתית ומבודדת עבור ה-bootstrap שלא תפריע ותדרוס שירותים אחרים
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new Microsoft.Extensions.FileProviders.PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "wwwroot", "bootstrap", "images")),
        RequestPath = "/bootstrap/images"
    });

// ----------------------------

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();