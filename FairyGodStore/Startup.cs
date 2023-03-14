using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FairyGodStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using FairyGodStore.MiddleWares;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Net;

namespace FairyGodStore
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
            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<DatabaseContext>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("DefaultDB"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            });

            //services.AddSwaggerGen(c =>
            //{
            //    //var jwtSecurityScheme = new OpenApiSecurityScheme
            //    //{
            //    //    BearerFormat = "JWT",
            //    //    Name = "Authorization",
            //    //    In = ParameterLocation.Header,
            //    //    Type = SecuritySchemeType.Http,
            //    //    Scheme = JwtBearerDefaults.AuthenticationScheme,
            //    //    Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

            //    //    Reference = new OpenApiReference
            //    //    {
            //    //        Id = JwtBearerDefaults.AuthenticationScheme,
            //    //        Type = ReferenceType.SecurityScheme
            //    //    }
            //    //};

            //    c.SwaggerDoc("v1", new OpenApiInfo { Title = "FairyGodStore", Version = "v1" });

            //    //c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            //    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //    {
            //        In = ParameterLocation.Header,
            //        Description = "Please insert JWT with Bearer into field",
            //        Name = "Authorization",
            //        Type = SecuritySchemeType.Http
            //    });

            //    c.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        {
            //            new OpenApiSecurityScheme
            //            {
            //               Reference = new OpenApiReference
            //               {
            //                 Type = ReferenceType.SecurityScheme,
            //                 Id = "Bearer"
            //               }
            //            },
            //            new string[] { }
            //        }
            //    });
            //});

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FairyGodStore", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            //app.UseSession();

            app.Use(async (context, next) =>
            {
                var JWToken = context.Request.Cookies["Authorization"];
                if (!JWToken.IsEmpty())
                    context.Request.Headers.Add("Authorization", "Bearer " + JWToken);

                await next();
                if (context.Response.StatusCode == 404 && !context.Response.HasStarted)
                    context.Response.Redirect("/error/404");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseStatusCodePages(context =>
            {
                var response = context.HttpContext.Response;
                if (response.StatusCode == (int)HttpStatusCode.Unauthorized ||
                    response.StatusCode == (int)HttpStatusCode.Forbidden)
                {
                    if (context.HttpContext.Request.Path.Value.ToLower().StartsWith("/api"))
                        response.Redirect("/api/authen");
                    else
                        response.Redirect("/authen");
                }
                return Task.CompletedTask;
            });

            app.UseAuthorization();

            //app.UseMiddleware<UserLoginMiddleWare>();
            app.UseMiddleware<SwaggerMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FairyGodStore v1");
                c.RoutePrefix = "api/docs";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
