using GraphQL.Server.Ui.Voyager;
using HotChocolateGQL.Context;
using HotChocolateGQL.GraphQLContext;
using HotChocolateGQL.GraphQLContext.Authors;
using HotChocolateGQL.GraphQLContext.Books;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotChocolateGQL
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            //DbContext
            services.AddPooledDbContextFactory<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //GraphQL
            services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddType<AuthorType>()
                .AddType<BookType>()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();
                
                //.AddProjections();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //GraphQL Subscription / WebSockets
            app.UseWebSockets();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            //Voyager
            app.UseGraphQLVoyager();
        }
    }
}
