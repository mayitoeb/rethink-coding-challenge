namespace webapi.Core.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, string policy)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy => policy
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
