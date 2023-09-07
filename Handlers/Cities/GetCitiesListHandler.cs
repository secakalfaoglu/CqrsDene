using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers;

public class GetCitiesListHandler : IRequestHandler<GetCitiesListQuery, List<Cities>>
{
    private readonly ICitiesRepository citiesRepository;
    
    public GetCitiesListHandler(ICitiesRepository _citiesRepository)
    {
        citiesRepository = _citiesRepository;
    }
    
    public async Task<List<Cities>> Handle(GetCitiesListQuery request, CancellationToken cancellationToken)
    {
        await Console.Out.WriteLineAsync("GET ALL ASYNC HANDLER");
        return await citiesRepository.GetAllAsync();
    }
}