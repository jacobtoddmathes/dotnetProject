using System.Security.Authentication;
using frontendBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// add backend http client
builder.Services.AddScoped(sp => new HttpClient { 
        BaseAddress = new Uri("https://localhost:5065")
     });

var handler = new HttpClientHandler()
{
    SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls13,
};

var client = new HttpClient(handler);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
