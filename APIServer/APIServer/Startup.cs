using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using APIServer.Services;
using NJsonSchema;
using NSwag.AspNetCore;

namespace APIServer
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
			services.AddScoped<UserService>();
			services.AddScoped<QuestionService>();
			services.AddScoped<ArticleService>();
			services.AddCors();
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
//			services.AddSwagger();
			services.AddSwaggerDocument();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
				app.UseDeveloperExceptionPage();
			else
				app.UseHsts();
			// Shows UseCors with CorsPolicyBuilder.
			app.UseCors(builder =>
				builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
//			app.UseHttpsRedirection();
			app.UseMvc();
//			app.UseStaticFiles();
			app.UseSwagger();
			app.UseSwaggerUi3();
		}
	}
}