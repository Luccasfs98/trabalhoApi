﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Associados.Data.Context;
using Associados.Data.Repositories;
using Associados.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Associados.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(i =>
                                    i.TokenValidationParameters = new TokenValidationParameters
                                    {
                                        ValidateIssuer = true,     
                                        ValidateAudience = true,  
                                        ValidateLifetime = false,
                                        ValidateIssuerSigningKey = true,
                                        ValidAudience = "TokenAssociadosApi",
                                        ValidIssuer = "TokenAssociadosApi",
                                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TokenAssociadosApi"))
                                    }
                    );
             services.AddDbContext<DataContext>(x =>
                x.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IAssociadoRepository, AssociadoRepository>();
            services.AddScoped<IDependenteRepository, DependenteRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
       public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseAuthentication();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
