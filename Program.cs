using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Dordea_Voicu_Lab2.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Dordea_Voicu_Lab2Context>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Dordea_Voicu_Lab2Context") ?? throw new InvalidOperationException("Connection string 'Dordea_Voicu_Lab2Context' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Dordea_Voicu_Lab2Context") ?? throw new InvalidOperationException("Connectionstring 'Dordea_Voicu_Lab2Context' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
.AddEntityFrameworkStores<LibraryIdentityContext>();
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

app.MapRazorPages();

app.Run();
