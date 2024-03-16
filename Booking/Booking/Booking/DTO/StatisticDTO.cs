namespace Booking.DTO
{
    public class StatisticDTO
    {
        public int totalAccount { get; set; }

        public int totalHomestay { get; set; }

        public int totalOrder { get; set; }

        public double? totalPrice { get; set; }

        public List<HomestayDTO> list { get; set; }


    }
}
