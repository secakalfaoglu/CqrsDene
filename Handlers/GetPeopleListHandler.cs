using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers
{
    public class GetPeopleListHandler : IRequestHandler<GetPeopleListQuery, List<Person>>
    {
        private readonly IPeopleRepository peopleRepository;
        public GetPeopleListHandler(IPeopleRepository _peopleRepository)
        {
            this.peopleRepository = _peopleRepository;
        }
        public async Task<List<Person>> Handle(GetPeopleListQuery request, CancellationToken cancellationToken)
        {
            await Console.Out.WriteLineAsync("GET ALL ASYNC HANDLER");
            return await peopleRepository.GetAllAsync();
        }
    }
}
