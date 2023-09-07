using CqrsDene.Models.Domain;
using MediatR;

namespace CqrsDene.Commands;

public class CreateCitiesCommand : IRequest<Cities>
{
    
    public string Name { get; set; }
   
    public int LisenceNumber { get; set; }
    
    public CreateCitiesCommand(string _Name,  int _LisenceNumber)
    {
        Name = _Name;
        LisenceNumber = _LisenceNumber;
    }
    
}
public class CitiesDeleteCommand : IRequest<Cities>
{
    public int Id { get; set; }
    public CitiesDeleteCommand(int _Id)
    {
        Id = _Id;
    }
}

public class CitiesUpdateCommand : IRequest<Cities>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LisenceNumber { get; set; }
    public CitiesUpdateCommand(int _Id, string _Name,  int _LisenceNumber)
    {
        Id = _Id;
        Name = _Name;
        LisenceNumber = _LisenceNumber;
    }
}