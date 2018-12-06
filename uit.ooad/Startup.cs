using System.Security.Claims;
using System.Text;
using GraphQL;
using GraphQL.Authorization;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using uit.ooad.ObjectTypes;
using uit.ooad.Queries;
using uit.ooad.Queries.Mutation;
using uit.ooad.Schemas;

namespace uit.ooad
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Auth
            services
               .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = Configuration["JWT:issuer"],
                        ValidAudience = Configuration["JWT:audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:key"]))
                    };
                });

            // GraphQL
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();

            services.AddSingleton<AppQuery>();
            services.AddSingleton<AppMutation>();

            services.AddSingleton<PatronCreateInput>();
            services.AddSingleton<PatronKindIdInput>();
            services.AddSingleton<CreateFloorInput>();

            services.AddSingleton<BillType>();
            services.AddSingleton<BookingType>();
            services.AddSingleton<EmployeeType>();
            services.AddSingleton<FloorType>();
            services.AddSingleton<HouseKeepingType>();
            services.AddSingleton<PatronKindType>();
            services.AddSingleton<PatronType>();
            services.AddSingleton<PositionType>();
            services.AddSingleton<RateType>();
            services.AddSingleton<ReceiptType>();
            services.AddSingleton<RoomKindType>();
            services.AddSingleton<RoomType>();
            services.AddSingleton<ServicesDetailType>();
            services.AddSingleton<ServiceType>();
            services.AddSingleton<VolatilityRateType>();

            services.AddSingleton<ISchema, AppSchema>();

            // GraphQL.DataLoader
            services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            services.AddSingleton<DataLoaderDocumentListener>();

            // GraphQL.Auth
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.TryAddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();
            services.AddTransient<IValidationRule, AuthorizationValidationRule>();
            services.TryAddSingleton(s =>
            {
                var authSettings = new AuthorizationSettings();
                authSettings.AddPolicy("AdminPolicy", _ => _.RequireClaim(ClaimTypes.Role, "Admin"));
                return authSettings;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.ApplicationServices.GetServices<IValidationRule>();

            app.UseCors(x => x
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials()
            );
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
