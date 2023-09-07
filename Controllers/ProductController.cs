using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDene.Controllers;

[Route("api/[controller]")]
[ApiController]

public class ProductController : ControllerBase
{
    private readonly IMediator mediator;
    
    public ProductController(IMediator _mediator)
    {
        mediator = _mediator;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        var productList = await mediator.Send(new GetProductListQuery());
        return Ok(productList);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Product), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> GetProduct(int id)
    {
        var product = await mediator.Send(new GetProductByIdQuery(id));
        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        var createdProduct = await mediator.Send(new CreateProductCommand(product.Name, product.Price));

        return CreatedAtAction(nameof(GetProduct), new { id = createdProduct.Id }, createdProduct);
    }
    
}