using CqrsMediator.DataStore;
using CqrsMediator.Model;
using CqrsMediator.Commands;
using MediatR;

namespace CqrsMediator.Handlers;

public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
{
    private readonly FakeDataStore _fakeDataStore;
    public AddProductHandler(FakeDataStore fakeDataStore)
    {
        _fakeDataStore = fakeDataStore;
    }
    public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        await _fakeDataStore.AddProduct(request.product);
        return request.product;
    }
}