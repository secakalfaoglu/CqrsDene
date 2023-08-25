using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using CqrsDene.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDene.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IMediator mediator;

    public PeopleController(IMediator _mediator)
    {
        mediator = _mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPeople()
    {
        var peopleList = await mediator.Send(new GetPeopleListQuery());
        return Ok(peopleList);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Person), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await mediator.Send(new GetPersonByIdQuery(id));
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    [ProducesResponseType(typeof(Person), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreatePerson(Person person)
    {
        var createdPerson = await mediator.Send(new CreatePersonCommand(person.FirstName, person.LastName));

        return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
    }
}