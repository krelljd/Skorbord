using Skorbord.Components;
using Microsoft.AspNetCore.ResponseCompression;
using Skorbord.Hubs;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSystemd();

var corsPolicy = "signalrPolicy";
builder.Services.AddCors(options => {
    options.AddPolicy(name: corsPolicy,
    policy => 
    {
        policy
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowCredentials()
        .WithOrigins("http://localhost:8000", "https://skorbord.app");
    });
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddResponseCompression(opts => 
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream"}
    );
});

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

app.UseCors(corsPolicy);

//app.UseHttpsRedirection();
app.UseResponseCompression();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.MapHub<ScoreHub>("/scorehub");


app.Run();
