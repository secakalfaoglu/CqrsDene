using CqrsDene.Models.Domain;
using CqrsDene.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDene.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PeopleController : ControllerBase
{
    private readonly IPeopleRepository peopleRepository;

    public PeopleController(IPeopleRepository _peopleRepository)
    {
        peopleRepository = _peopleRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetPeople()
    {
        var people = await peopleRepository.GetAllAsync();
        return Ok(people);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var person = await peopleRepository.GetByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePerson(Person person)
    {
        var createdPerson = await peopleRepository.CreateAsync(person);
        return CreatedAtAction(nameof(GetPerson), new { id = createdPerson.Id }, createdPerson);
    }
}