using eventando.Dados;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EventosContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("EventosConnection"))
);

var app = builder.Build();

//Configurando injeção de dependência
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<EventosContext>();
        DbInitializer.Initialize(context); //cria o BD caso não exista
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger>();
        logger.LogError(ex, ex.Message);
        throw;
    }
};

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
