using CqrsDene.Models.Domain;
using MediatR;

namespace CqrsDene.Queries;

public class GetCitiesByIdQuery : IRequest<Cities>
{
    public GetCitiesByIdQuery(int id)
    {
        Id = id;
    }
    
    public int Id { get; set; }
}