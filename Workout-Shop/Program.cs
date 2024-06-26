using Workout_Shop.Data;
using Workout_Shop.Data.Cart;
using Workout_Shop.Data.Service;
using Workout_Shop.Data.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IInstructorService, InstructorsService > ();
builder.Services.AddScoped<IMainInstrcutorsService, MainInstrcutorService>();
builder.Services.AddScoped<IGymsService, GymsService>();
builder.Services.AddScoped<IPlansService, PlansService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IOrderService, OrdersService>();

builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddSession();

var connString = builder.Configuration.GetConnectionString("EccomerceGym");
builder.Services.AddSqlite<ApplicationDBContext>(connString);


var app = builder.Build();

AppDBInitialiser.Seed(app);


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
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


