using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureAD.UI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Web;
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
				options.Authority = "https://login.microsoftonline.com/e9e18706-7eba-446b-a3df-e1bde79cf7c0/v2.0";
				//options.RequireHttpsMetadata = false;
				options.Audience = "bdedf839-fb9e-4276-8f4d-6608468c1fa6";
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
