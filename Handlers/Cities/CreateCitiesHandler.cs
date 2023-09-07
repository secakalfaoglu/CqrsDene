using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers;

public class CreateCitiesHandler : IRequestHandler<CreateCitiesCommand, Cities>
{
    private readonly ICitiesRepository citiesRepository;
    
    public CreateCitiesHandler(ICitiesRepository _citiesRepository)
    {
        citiesRepository = _citiesRepository;
    }
    
    public async Task<Cities> Handle(CreateCitiesCommand command, CancellationToken cancellationToken)
    {
        var cities = new Cities
        {
            Name = command.Name,
            LisenceNumber = command.LisenceNumber,
        };
        return await citiesRepository.CreateAsync(cities);
    }
}