
namespace BookingSystem.ApplicationCore.Entities.ReadModels
{
    public partial class BookingExtraService
    {
        public int BookingId { get; set; }
        public int ExtraServiceId { get; set; }

        public virtual Booking Booking { get; set; }
        public virtual ExtraService ExtraService { get; set; }
    }
}
