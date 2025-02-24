using Application.AutoMapper;

namespace SafeMoneyAPI.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }   
    }
}
