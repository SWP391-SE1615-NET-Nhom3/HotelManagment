namespace Booking.DTO
{
    public class EditDTO
    {
        public int id { get; set; }

        public string name { get; set; }

        public string address { get; set; }

        public int? bedroom { get; set; }

        public int? bathroom { get; set; }

        public double? priceOneNight { get; set; }

        public string detail { get; set; }

        public string image { get; set; }

        public int? cate_id { get; set; }

        public string owner { get; set; }

    }
}
