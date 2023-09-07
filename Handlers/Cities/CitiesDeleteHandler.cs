using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers;

public class CitiesDeleteHandler : IRequestHandler<CitiesDeleteCommand, Cities>
{

    private readonly ICitiesRepository citiesRepository;

    public CitiesDeleteHandler(ICitiesRepository _citiesRepository)
    {
        citiesRepository = _citiesRepository;
    }

    public async Task<Cities> Handle(CitiesDeleteCommand command, CancellationToken cancellationToken)
    {
        var cities = await citiesRepository.GetByIdAsync(command.Id);
        if (cities == null)
        {
            throw new Exception("Cities not found");
        }
        return await citiesRepository.DeleteAsync(cities);
    }
}