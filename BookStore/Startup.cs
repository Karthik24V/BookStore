using BookStore.Domain.Model;
using BookStore.Services.Configuration;
using BookStore.Services.ViewModel.Books;
using System.Text.Json.Serialization;

namespace BookStore.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public void ConfigureServices(IServiceCollection services)
    {

        var mongoDBConnectionInfo = new MongoDBConnectionInfo()
        {
            IsEncoded = (Environment.GetEnvironmentVariable("IsEncoded") != null) && Convert.ToBoolean(Environment.GetEnvironmentVariable("IsEncoded")),
            ConnectionString = Environment.GetEnvironmentVariable("ConnectionString"),
            DatabaseName = Environment.GetEnvironmentVariable("DatabaseName"),
            IsLocalSever = ((Environment.GetEnvironmentVariable("IsLocalServer") != null) && Convert.ToBoolean(Environment.GetEnvironmentVariable("IsLocalServer"))),
            DBType = Environment.GetEnvironmentVariable("DBType") ?? ""
        };
        services.AddSingleton(mongoDBConnectionInfo);

        //var awsS3Config = new AWSS3Config()
        //{
        //    Bucket = Environment.GetEnvironmentVariable("BucketName"),
        //    AccessKey = Environment.GetEnvironmentVariable("AccessKey"),
        //    SecretKey = Environment.GetEnvironmentVariable("SecretKey"),
        //    Region = Environment.GetEnvironmentVariable("Region")
        //};
        //services.AddSingleton(awsS3Config);

        //var endPointConfig = Configuration.GetSection(nameof(EndPointConfig)).Get<EndPointConfig>();
        //services.AddSingleton(endPointConfig);

        services.AddBookStoreService();
        services.AddAutoMapper();
        services.AddMediatRConfig();
        services.AddControllers();
        //services.AddValidators();
        //Use this code to remove the NULL values from the result JSON.
        //services.AddMvc().AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
        services.SwaggerConfiguration();
        services.AddSwaggerGen();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI();

        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        // global cors policy
        app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pharmacy Integration API");
        });
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}
