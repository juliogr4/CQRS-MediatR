using CqrsMediator.DataStore;
using CqrsMediator.Model;
using CqrsMediator.Queries;
using MediatR;

namespace CqrsMediator.Handlers;

public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
{
    private readonly FakeDataStore _fakeDataStore;
    public GetProductsHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }
    public Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var products = _fakeDataStore.GetAllProducts();
        return products;
    }
}