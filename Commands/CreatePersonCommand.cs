using CqrsDene.Models.Domain;
using MediatR;

namespace CqrsDene.Commands
{
    public class CreatePersonCommand : IRequest<Person>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public CreatePersonCommand(string _FirstName, string _LastName)
        {
            FirstName = _FirstName;
            LastName = _LastName;
        }


    }
}
