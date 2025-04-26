using LibraryWEB.DataBase;
using LibraryWEB.Profiles;
using LibraryWEB.Repository.Implementation;
using LibraryWEB.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace LibraryWEB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<LibraryDbContext>(ops => ops.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString"))); 
            builder.Services.AddAutoMapper(typeof(CustomProfile));
            builder.Services.AddScoped<IBookRepository,BookRepository>();
            builder.Services.AddScoped<IAuthorRepository,AuthorRepository>();
            builder.Services.AddScoped<IAuthorContactRepository, AuthorContactRepository>();
            builder.Services.AddScoped<IBookCategoryRepository, BookCategoryRepository>();
            builder.Services.AddScoped<IPublisherRepository, PublisherRepository>();


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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
