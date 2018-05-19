using System.Globalization;
using CompareDb.Infrastructure;
using CompareDb.Interfaces.EF;
using CompareDb.Interfaces.MongoDB;
using CompareDb.Managers;
using CompareDb.Managers.EF;
using CompareDb.Managers.MongoDB;
using CompareDb.Models.EF;
using CompareDb.Repositories.EF;
using CompareDb.Repositories.MongoDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CompareDb
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
            services.AddMvc();
            services.AddScoped<ApplicationContext, ApplicationContext>();
            RegisterManagers(services);
            RegisterRepositories(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DBComparator API", Version = "v1" });
            });
            services.AddCors();
        }

        private static void RegisterManagers(IServiceCollection services)
        {
            services.AddScoped<IUserManager, UserManager>();
            services.AddScoped<IHospitalManager, HospitalManager>();
            services.AddScoped<IDepartmentManager, DepartmentManager>();
            services.AddScoped<ILaborManager, LaborManager>();
            services.AddScoped<IDrugstoreManager, DrugstoreManager>();
            services.AddScoped<IContractManager, ContractManager>();
            services.AddScoped<IHistoryManager, HistoryManager>();

            services.AddScoped<IPatientManager, PatientManager>();
            services.AddScoped<IEFHospitalManager, EFHospitalManager>();
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ILaborRepository, LaborRepository>();
            services.AddScoped<IDrugstoreRepository, DrugstoreRepository>();
            services.AddScoped<IContractRepository, ContractRepository>();
            services.AddScoped<IHistoryRepository, HistoryRepository>();
           

            services.AddScoped<IRepository<Patient>, EFPatientRepository>();
            services.AddScoped<IRepository<Hospital>, EFHospitalRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", $"{CultureInfo.CurrentCulture.TextInfo.ToTitleCase("DB Comparator")} API");
            });
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        }
    }
}
