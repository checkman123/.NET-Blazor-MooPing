using Carter;
using MooPing.Components;

var builder = WebApplication.CreateBuilder(args);
#region Services
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCarter();

builder.Services.AddWebOptimizer(pipeline =>
{
    pipeline.AddCssBundle("/css/site.css", "scss/site.scss");
    pipeline.MinifyJsFiles("js/**/*.js", "js/**/*.js");
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseWebAssemblyDebugging();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/StatusCode/{0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapCarter(); //Map Api

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(MooPing.Client._Imports).Assembly);

app.Run();
