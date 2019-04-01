namespace BookingSystem.Common.Interfaces
{
    public interface IBookingConfiguration
    {
        int LockTimeOutMinutes { get; }
        int MaxRoomSize { get; }
    }
}
