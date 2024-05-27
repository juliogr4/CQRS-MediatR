using CqrsMediator.DataStore;
using MediatR;

namespace CqrsMediator.Notification;

public class CacheInvalidationHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _fakeDataStore;
    public CacheInvalidationHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccured(notification.product, "Cache Invalidated");
        await Task.CompletedTask;
    }
}