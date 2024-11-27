var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



/* adicionar o addDistributed e o addSession para funcionar a session*/
/* 
Abaixo são exemplos de configuração para adicionar a sessao
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
*/

builder.Services.AddSession();//Para funcionar a session
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSession();// Para funcionar a session


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "/{controller=Imobiliaria}/{action=PageHome}/{id?}");

app.Run();
