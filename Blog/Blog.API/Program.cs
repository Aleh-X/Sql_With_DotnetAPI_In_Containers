
using Blog.API.EFConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Blog.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<BlogContext>(options =>
        {
            var connectionString = builder.Configuration
            .GetSection("BlogDbConnectionString")
            .Get<string>();

            options.UseSqlServer(connectionString, options =>
            {
                options.MigrationsAssembly(typeof(Program).Assembly.FullName);
            });
        });


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        //if (app.Environment.IsDevelopment())
        //{
        //    using var scope = app.Services.CreateScope();

        //    var context = scope.ServiceProvider.GetRequiredService<BlogContext>();

        //    await new BlogContextSeed().SeedAsync(context);
        //}

        app.Run();
    }
}

