using CqrsDene.Models.Domain;
using MediatR;

namespace CqrsDene.Queries;

public class GetProductListQuery:IRequest<List<Product>>
{
    
}