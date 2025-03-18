using EventManager.Components;
using EventManager.Services;
using EventManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Corrigido para Scoped (era Singleton antes, o que causava o erro)
builder.Services.AddScoped<UserSessionService>();
builder.Services.AddScoped<AttendanceService>();
builder.Services.AddSingleton<EventData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
