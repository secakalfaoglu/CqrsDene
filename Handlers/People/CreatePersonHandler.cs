using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Repositories;
using MediatR;

namespace CqrsDene.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Person>
    {
        private readonly IPeopleRepository peopleRepository;

        public CreatePersonHandler(IPeopleRepository _peopleRepository)
        {
            peopleRepository = _peopleRepository;
        }
        public async Task<Person> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
        {
            var Person= new Person
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
            };
            return await peopleRepository.CreateAsync(Person);
        }
    }
}
