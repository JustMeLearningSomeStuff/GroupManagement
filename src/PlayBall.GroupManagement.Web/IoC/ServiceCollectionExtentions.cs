using PlayBall.GroupManagement.Business.Impl.Services;
using PlayBall.GroupManagement.Business.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services)
        {
            services.AddSingleton<IGroupService, InMemoryGroupService>();

            return services;
        }
    }
}
