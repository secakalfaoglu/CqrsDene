using CqrsDene.Commands;
using CqrsDene.Models.Domain;
using CqrsDene.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CqrsDene.Controllers;


[Route("api/[controller]")]
[ApiController]

public class CitiesController : ControllerBase
{
    private readonly IMediator mediator;
    
    public CitiesController(IMediator _mediator)
    {
        mediator = _mediator;
    }
    
    [HttpGet]
    
    public async Task<IActionResult> GetCities()
    {
        var citiesList = await mediator.Send(new GetCitiesListQuery());
        return Ok(citiesList);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Cities), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    
    public async Task<IActionResult> GetCity(int id)
    {
        var city = await mediator.Send(new GetCitiesByIdQuery(id));
        if (city == null)
        {
            return NotFound();
        }
        
        return Ok(city);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(Cities), StatusCodes.Status201Created)]
    
    public async Task<IActionResult> CreateCity(Cities city)
    {
        var createdCity = await mediator.Send(new CreateCitiesCommand(city.Name, city.LisenceNumber));
        
        return CreatedAtAction(nameof(GetCity), new { id = createdCity.Id }, createdCity);
    }
    
    
    [HttpPost("delete")]
    [ProducesResponseType(typeof(Cities), StatusCodes.Status201Created)]
    
    public async Task<IActionResult> DeleteCity(CitiesDelete city)
    {
        var deletedCity = await mediator.Send(new CitiesDeleteCommand(city.Id));
        
        return CreatedAtAction(nameof(GetCity), new { id = deletedCity.Id }, deletedCity);
    }
    
    [HttpPost("update")]
    [ProducesResponseType(typeof(Cities), StatusCodes.Status201Created)]
    
    public async Task<IActionResult> UpdateCity(Cities city)
    {
        var updatedCity = await mediator.Send(new CitiesUpdateCommand(city.Id, city.Name, city.LisenceNumber));
        
        return CreatedAtAction(nameof(GetCity), new { id = updatedCity.Id }, updatedCity);
    }
    
    
    
}