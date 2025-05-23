using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    var html = @$"
        <!DOCTYPE html>
        <html>
            <body>
                <h1>Super Market Manager</h1>
                <h4>Welcome to the Super Market Manager</h4>
            </body>
        </html>";
    WriteHtml(context, html);
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();

void WriteHtml(HttpContext context, string html)
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    context.Response.WriteAsync(html);
}
