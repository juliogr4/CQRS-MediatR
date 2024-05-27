using CqrsMediator.Model;
using MediatR;

namespace CqrsMediator.Queries;

public record GetProductByIdQuery(int id) : IRequest<Product>;