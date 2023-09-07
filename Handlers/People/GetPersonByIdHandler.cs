using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers
{
    public class GetPersonByIdHandler:IRequestHandler<GetPersonByIdQuery,Person?>
    {
        private readonly IPeopleRepository peopleRepository;
        public GetPersonByIdHandler(IPeopleRepository _peopleRepository)
        {
            peopleRepository = _peopleRepository;
        }
        public async Task<Person?> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("GET BY ID ASYNC HANDLER");
            return await peopleRepository.GetByIdAsync(request.Id);
        }
    }
    
}
