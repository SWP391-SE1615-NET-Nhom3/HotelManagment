namespace Booking.DTO
{
    public class OrderShowDTO
    {
        public string nameHomeStay { get; set; }

        public int? status { get; set; }

        public string usernameBooking { get; set; }

        public DateTime? checkin { get; set; }

        public DateTime? checkout { get; set; }
    }
}
