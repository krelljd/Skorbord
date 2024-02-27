using Skorbord.Components;
using Microsoft.AspNetCore.ResponseCompression;
using Skorbord.Hubs;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// builder.Services.AddSignalRCore();
builder.Services.AddResponseCompression(opts => 
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream"}
    );
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowedOrigins",
                      policy =>
                      {
                          policy.WithOrigins("http://skorbord.app", "https://skorbord.app", "http://localhost", "https://localhost");
                          policy.WithMethods("GET", "POST");
                          policy.AllowCredentials();
                      });
});

builder.Services.AddFluentUIComponents();

var app = builder.Build();

app.UseResponseCompression();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

webSocketOptions.AllowedOrigins.Add("https://skorbord.app");
webSocketOptions.AllowedOrigins.Add("http://skorbord.app");
webSocketOptions.AllowedOrigins.Add("https://localhost");
webSocketOptions.AllowedOrigins.Add("http://localhost");

app.UseWebSockets(webSocketOptions);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
    
app.MapHub<ScoreHub>("/scorehub");

app.Run();
