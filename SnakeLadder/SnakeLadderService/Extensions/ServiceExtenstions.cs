using SnakeLadder.Core;
using SnakeLadder.Core.Contract;

namespace SnakeLadderService.Extensions
{
    public static class ServiceExtenstions
    {
        /// <summary>
        /// Add application logics into the application dependency injection registry.
        /// </summary>
        /// <param name="services"></param>
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<ISnakeLadderLogic, SnakeLadderLogic>();
        }

    }
}
