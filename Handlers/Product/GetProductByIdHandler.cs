using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using MediatR;
using CqrsDene.Repositories;


namespace CqrsDene.Handlers;

public class GetProductByIdHandler:IRequestHandler<GetProductByIdQuery,Product>
{
    private readonly IProductRepository productRepository;

    public GetProductByIdHandler(IProductRepository _productRepository)
    {
        productRepository = _productRepository;
    }
    public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        
        return await productRepository.GetByIdAsync(request.Id);
    }
}
