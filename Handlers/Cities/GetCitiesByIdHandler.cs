using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers;

public class GetCitiesByIdHandler : IRequestHandler<GetCitiesByIdQuery, Cities>
{
    private readonly ICitiesRepository citiesRepository;
    
    public GetCitiesByIdHandler(ICitiesRepository _citiesRepository)
    {
        citiesRepository = _citiesRepository;
    }
    
    public async Task<Cities?> Handle(GetCitiesByIdQuery request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync("GET ALL ASYNC HANDLER");
        return await citiesRepository.GetByIdAsync(request.Id);
    }
    
}