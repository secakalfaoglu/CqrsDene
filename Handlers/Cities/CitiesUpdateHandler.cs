using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers;

public class CitiesUpdateHandler : IRequestHandler<CitiesUpdateCommand, Cities>
{
    private readonly ICitiesRepository citiesRepository;
    
    public CitiesUpdateHandler(ICitiesRepository _citiesRepository)
    {
        citiesRepository = _citiesRepository;
    }
    
    public async Task<Cities> Handle(CitiesUpdateCommand command, CancellationToken cancellationToken)
    {
        var cities = await citiesRepository.GetByIdAsync(command.Id);
        if (cities == null)
        {
            throw new Exception("Cities not found");
        }
        cities.Name = command.Name;
        cities.LisenceNumber = command.LisenceNumber;
        return await citiesRepository.UpdateAsync(cities);
    }
}