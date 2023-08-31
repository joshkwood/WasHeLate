namespace WasJohnLate.Interfaces;

public interface ITrackingRepository
{
    public bool CreateEntry(DateTime timeEntered);
    public bool EditEntry();
    public bool Save();
}