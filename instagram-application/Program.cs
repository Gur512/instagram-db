using instagram_application.BLL;
using instagram_application.DAL;
using Microsoft.EntityFrameworkCore;

namespace instagram_application
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<InstagramDatabaseContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddTransient<UserRepository>();
            builder.Services.AddTransient<UserServices>();

            builder.Services.AddTransient<PostServices>();
            builder.Services.AddTransient<PostRepository>();

            builder.Services.AddTransient<StoryServices>();
            builder.Services.AddTransient<StoryRepository>();

            builder.Services.AddTransient<LikeServices>();
            builder.Services.AddTransient<LikeRepository>();

            builder.Services.AddTransient<CommentServices>();
            builder.Services.AddTransient<CommentRepository>();

            builder.Services.AddTransient<FollowServices>();
            builder.Services.AddTransient<FollowRepository>();

            builder.Services.AddTransient<StoryviewServices>();
            builder.Services.AddTransient<StoryviewRepository>();

            builder.Services.AddTransient<DirectMessageServices>();
            builder.Services.AddTransient<DirectMessageRepository>();

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

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
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
