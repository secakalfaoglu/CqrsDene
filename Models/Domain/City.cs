namespace CqrsDene.Models.Domain;

public class Cities
{
    public int Id { get; set; }
    
    public required string Name { get; set; }
    
    public required int LisenceNumber { get; set; }
}

public class CitiesDelete
{
    public int Id { get; set; }
}

public class CitiesUpdate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int LisenceNumber { get; set; }
}