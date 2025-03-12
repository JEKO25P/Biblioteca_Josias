using Biblioteca_Josias_83.Context;
using Biblioteca_Josias_83.Services.IServices;
using Biblioteca_Josias_83.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")));

//Las inyecciones de dependencias
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IRolServices, RolServices>();
builder.Services.AddScoped<ICategoryServices, CategoryService>();
builder.Services.AddScoped<IAuthorServices, AuthorService>();
builder.Services.AddScoped<IBookServices, BookService>();
builder.Services.AddScoped<ILoginServices, LoginService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["Jwt:Audience"],

            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });



var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

//Rutas del administrador
app.MapControllerRoute(
    name: "role",
    pattern: "Role/{action=IndexRoles}/{id?}",
    defaults: new { controller = "Role" });

app.MapControllerRoute(
    name: "category",
    pattern: "Category/{action=IndexCategorias}/{id?}",
    defaults: new { controller = "Category" });

app.MapControllerRoute(
    name: "author",
    pattern: "Author/{action=IndexAutores}/{id?}",
    defaults: new { controller = "Author" });

app.MapControllerRoute(
    name: "book",
    pattern: "Book/{action=IndexLibros}/{id?}",
    defaults: new { controller = "Book" });

app.MapControllerRoute(
    name: "user",
    pattern: "User/{action=Index}/{id?}",
    defaults: new { controller = "User" });
app.MapControllerRoute(
    name: "role",
    pattern: "Role/{action=IndexRoles}/{id?}",
    defaults: new { controller = "Role" });

app.MapControllerRoute(
    name: "category",
    pattern: "Category/{action=IndexCategorias}/{id?}",
    defaults: new { controller = "Category" });

app.MapControllerRoute(
    name: "author",
    pattern: "Author/{action=IndexAutores}/{id?}",
    defaults: new { controller = "Author" });

app.MapControllerRoute(
    name: "dahsboardAdmin",
    pattern: "AdminDashboard/{action=AdminDashboard}/{id?}",
    defaults: new { controller = "Admin" });

app.MapControllerRoute(
    name: "user",
    pattern: "User/{action=Index}/{id?}",
    defaults: new { controller = "User" });

//Rutas del usuario
app.MapControllerRoute(
    name: "homeUsuario",
    pattern: "home/{action=Home}/{id?}",
    defaults: new { controller = "Usuario" });
app.MapControllerRoute(
    name: "libros",
    pattern: "Libros/{action=Libros}/{id?}",
    defaults: new { controller = "Usuario" });
app.MapControllerRoute(
    name: "autores",
    pattern: "Autores/{action=Autores}/{id?}",
    defaults: new { controller = "Usuario" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");


app.MapControllerRoute(
    name: "dahsboardAdmin",
    pattern: "AdminDashboard/{action=AdminDashboard}/{id?}",
    defaults: new { controller = "Admin" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");


app.Run();