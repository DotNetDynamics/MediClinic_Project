    using Microsoft.EntityFrameworkCore;
    using MediClinic_Project.Models;
    var builder = WebApplication.CreateBuilder(args);


    builder.Services.AddDbContext<MediClinicDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MediClinicDB")));
// Add services to the container.
builder.Services.AddControllersWithViews();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();


    app.Run();

Console.WriteLine("Hello World");


