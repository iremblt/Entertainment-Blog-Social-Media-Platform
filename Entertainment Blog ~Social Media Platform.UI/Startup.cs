using Entertainment_Blog.Bussiness.Abstract;
using Entertainment_Blog.Bussiness.Concrete.Mapping;
using Entertainment_Blog.Bussiness.Concrete.Services;
using Entertainment_Blog.DataAccess.Abstract;
using Entertainment_Blog.DataAccess.Concrete;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Contexts;
using Entertainment_Blog.DataAccess.Concrete.EntityFramework.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Entertainment_Blog__Social_Media_Platform.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<EntertainmentBlogContext>();
            services.AddScoped<IPostRepository,EfPostRepository>();
            services.AddScoped<ICategoryRepository,EfCategoryRepository>();
            services.AddScoped<ITagRepository,EfTagRepository>();
            services.AddScoped<IPostService, PostServices>();
            services.AddScoped<ICategoryService, CategoryServices>();
            services.AddScoped<ITagService, TagServices>();
            services.AddAutoMapper(typeof(AutoMappingProfile));
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                SeedData.Seed(app);
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
