namespace WasJohnLate.Models;

public class EntryTime
{ 
    public Guid Id { get; set; }
    public string RecorderName { get; set; }
    public DateTime EntryDateTime { get; set; }
    public bool WasJohnLate { get; set; }
    public string EntryLocation { get; set; }
    
}