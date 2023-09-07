using CqrsDene.Models.Domain;
using MediatR;


namespace CqrsDene.Commands;

public class CreateProductCommand : IRequest<Product>
{
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public CreateProductCommand(string _Name, decimal _Price)
    {
        Name = _Name;
        Price = _Price;
    }
}