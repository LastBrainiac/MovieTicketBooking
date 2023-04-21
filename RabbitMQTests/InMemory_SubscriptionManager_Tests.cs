namespace RabbitMQTests
{
    public class InMemory_SubscriptionManager_Tests
    {
        [Fact]
        public void AfterCreationShouldBeEmpty()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            Assert.True(manager.IsEmpty);
        }

        [Fact]
        public void AfterOneEventSubscriptionShouldContainTheEvent()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.True(manager.HasSubscriptionsForEvent<TestIntegrationEvent>());
        }

        [Fact]
        public void AfterAllSubscriptionsAreDeletedEventShouldNoLongerExists()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            manager.RemoveSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.False(manager.HasSubscriptionsForEvent<TestIntegrationEvent>());
        }

        [Fact]
        public void DeletingLastSubscriptionShouldRaiseOnDeletedEvent()
        {
            bool raised = false;
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.OnEventRemoved += (o, e) => raised = true;
            manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            manager.RemoveSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            Assert.True(raised);
        }

        [Fact]
        public void GetHandlersForEventShouldReturnAllHandlers()
        {
            var manager = new InMemoryEventBusSubscriptionsManager();
            manager.AddSubscription<TestIntegrationEvent, TestIntegrationEventHandler>();
            manager.AddSubscription<TestIntegrationEvent, TestIntegrationOtherEventHandler>();
            var handlers = manager.GetHandlersForEvent<TestIntegrationEvent>();
            Assert.Equal(2, handlers.Count());
        }
    }
}
