using CatApp.Interfaces;
using CatApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// dependency injecting Http Client
builder.Services.AddHttpClient();

// Adding Catservice to service container for dependency injection
builder.Services.AddSingleton<ICatService>( x => 
new CatService(
    x.GetRequiredService<HttpClient>(), 
    x.GetRequiredService<IConfiguration>())
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
