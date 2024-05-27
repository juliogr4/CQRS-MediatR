using CqrsMediator.Model;
using CqrsMediator.Commands;
using CqrsMediator.Notification;
using CqrsMediator.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsMediator.Controller;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase 
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts() 
    {
        var products = _mediator.Send(new GetProductsQuery());
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product) 
    {
        var productToReturn = await _mediator.Send(new AddProductCommand(product));

        await _mediator.Publish(new ProductAddedNotification(productToReturn));
        
        return CreatedAtAction(nameof(GetProductById), new { id = productToReturn.Id }, productToReturn);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var product = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(product);
    }
}