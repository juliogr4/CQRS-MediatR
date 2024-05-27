using CqrsMediator.Model;
using MediatR;

namespace CqrsMediator.Notification;

public record ProductAddedNotification(Product product) : INotification;