using CqrsMediator.DataStore;
using CqrsMediator.Model;
using CqrsMediator.Queries;
using MediatR;

namespace CqrsMediator.Handlers;

public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
{
    private readonly FakeDataStore _fakeDataStore;
    public GetProductByIdHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fakeDataStore.GetProductById(request.id);
    }
}