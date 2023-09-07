using CqrsDene.Models.Domain;



using MediatR;

namespace CqrsDene.Queries;

public class GetProductByIdQuery:IRequest<Product>
{
    public GetProductByIdQuery(int id)
    {
        Id = id;
    }

    public int Id { get; set; }
}
