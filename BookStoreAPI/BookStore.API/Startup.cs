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
using Microsoft.OpenApi.Models;
using BookStore.Service.AuthorOperations;

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

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "BookStore API",
                    Version = "v1"
                });
            });
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

            //Swagger API documentation
            app.UseSwagger();
            app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "BookStore API"));
        }

        private void ConfigureBookStoreServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();

            //Repository
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
