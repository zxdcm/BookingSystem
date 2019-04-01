namespace BookingSystem.ReadPersistence.Utils
{
    public class DbActions
    {
        public const string ExecuteGetAvailableHotelsSp =
            "EXECUTE " + DbObjects.GetAvailableHotelsSp + DbObjects.GetAvailableHotelsSpParams;
    }
}
