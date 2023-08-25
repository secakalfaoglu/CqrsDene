using CqrsDene.Models.Domain;
using MediatR;

namespace CqrsDene.Queries
{
    public class GetPersonByIdQuery:IRequest<Person>
    {
        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
