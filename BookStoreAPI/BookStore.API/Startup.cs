using BookStore.DataAccess;
using BookStore.DataAccess.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using BookStore.Service.BookOperations;
using BookStore.DataAccess.RepositoryInterfaces;
using BookStore.DataAccess.RepositoryImplementations;

namespace BookStore.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            var defaultConnectionString = Configuration.GetConnectionString("BookStoreDbContext");

            services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookStoreDbContext")));

            services.AddScoped<IDatabaseOperations, DatabaseOperations>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddMaps("BookStore.Service");
            });

            IMapper mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            ConfigureBookStoreServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<IDatabaseOperations>().ConfigureDatabase();
            }
        }

        private void ConfigureBookStoreServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IBookService, BookService>();

            //Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
