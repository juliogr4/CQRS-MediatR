using CqrsMediator.DataStore;
using MediatR;

namespace CqrsMediator.Notification;

public class EmailHandler : INotificationHandler<ProductAddedNotification>
{
    private readonly FakeDataStore _fakeDataStore;
    public EmailHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;
    public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
    {
        await _fakeDataStore.EventOccured(notification.product, "Email sent");
        await Task.CompletedTask;
    }
}