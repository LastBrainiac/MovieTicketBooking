using EventBusBase;
using EventBusBase.Interfaces;

namespace MTBS.BasketAPI.ExtensionMethods
{
    public static class ServiceCollectionExtensionMethods
    {
        public static IServiceCollection RegisterEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBus, EventBusRabbitMQ>(sp => {
                var subscriptionClientName = configuration["EventBus:SubscriptionClientName"];
                var rabbitMQPersistentConnection = sp.GetRequiredService<IRabbitMQPersistentConnection>();
                var eventBusSubscriptionsManager = sp.GetRequiredService<IEventBusSubscriptionsManager>();

                var retryCount = 5;
                if (!string.IsNullOrEmpty(configuration["EventBus:RetryCount"]))
                {
                    retryCount = int.Parse(configuration["EventBus:RetryCount"]);
                }

                return new EventBusRabbitMQ(rabbitMQPersistentConnection, sp, eventBusSubscriptionsManager, subscriptionClientName, retryCount);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();

            return services;
        }
    }
}
