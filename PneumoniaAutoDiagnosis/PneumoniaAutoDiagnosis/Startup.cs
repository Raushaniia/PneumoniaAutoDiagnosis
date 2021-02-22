using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
			//services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
			//	.AddMicrosoftIdentityWebApp(Configuration.GetSection("AzureAd"));

			//services.AddControllersWithViews(options =>
			//{
			//	var policy = new AuthorizationPolicyBuilder()
			//		.RequireAuthenticatedUser()
			//		.Build();
			//	options.Filters.Add(new AuthorizeFilter(policy));
			//});

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
			//app.UseAuthentication();
			//app.UseAuthorization();



			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
