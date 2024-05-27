using CqrsMediator.Model;
using MediatR;

namespace CqrsMediator.Queries;

public record GetProductsQuery() : IRequest<IEnumerable<Product>>;