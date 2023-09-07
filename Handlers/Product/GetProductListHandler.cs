using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers;

public class GetProductListHandler: IRequestHandler<GetProductListQuery, List<Product>>
{
    private readonly IProductRepository productRepository;
    
    public GetProductListHandler(IProductRepository _productRepository)
    {
        this.productRepository = _productRepository;
    }
    public async Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync("GET ALL ASYNC HANDLER");
        return await productRepository.GetAllAsync();
    }

}