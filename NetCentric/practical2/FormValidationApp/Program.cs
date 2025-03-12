var builder = WebApplication.CreateBuilder(args);

// Add services to the container (Equivalent to ConfigureServices)
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline (Equivalent to Configure)
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// Configure the endpoints for MVC controllers (Equivalent to UseEndpoints)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Form}/{action=Index}/{id?}");

app.Run();
