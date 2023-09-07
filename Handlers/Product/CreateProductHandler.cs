using CqrsDene.Models.Domain;
using MediatR;
using CqrsDene.Commands;
using CqrsDene.Repositories;

namespace CqrsDene.Handlers;

public class CreateProductHandler : IRequestHandler<CreateProductCommand, Product>
{
    private readonly IProductRepository productRepository;

    public CreateProductHandler(IProductRepository _productRepository)
    {
        productRepository = _productRepository;
    }
    public async Task<Product> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = command.Name,
            Price = command.Price,
        };
        return await productRepository.CreateAsync(product);
    }
    
}