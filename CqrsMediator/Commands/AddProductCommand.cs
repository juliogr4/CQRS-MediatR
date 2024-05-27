using CqrsMediator.Model;
using MediatR;

namespace CqrsMediator.Commands;

public record AddProductCommand(Product product): IRequest<Product>;

