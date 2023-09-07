using CqrsDene.Models.Domain;
using MediatR;

namespace CqrsDene.Queries;

public class GetCitiesListQuery : IRequest<List<Cities>>
{
    
}