
namespace BookingSystem.ReadPersistence.ReadModels
{
    public partial class HotelImage
    {
        public int HotelId { get; set; }
        public int ImageId { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Image Image { get; set; }
    }
}
