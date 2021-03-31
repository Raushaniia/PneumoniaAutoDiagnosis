using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using PneumoniaAutoDiagnosis.DAL;
using PneumoniaAutoDiagnosis.Services;

namespace PneumoniaAutoDiagnosis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.Authority = "https://login.microsoftonline.com/f0510c5e-9b40-49d1-bd83-b454cd4e4f43/v2.0";
                options.RequireHttpsMetadata = false;
                options.Audience = "033b9b7d-247d-423b-9f5e-053b4b2e07b1";
            });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));


            services.Configure<DiagnosesDbDatabaseSettings>(
                Configuration.GetSection(nameof(DiagnosesDbDatabaseSettings)));

            services.AddSingleton<IDiagnosesDbDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<DiagnosesDbDatabaseSettings>>().Value);

            services.AddSingleton<BaseDatabaseService>();

            services.AddSingleton<PatientService>();

            services.AddSingleton<PatientCardService>();

            services.AddSingleton<UserService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("MyPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
