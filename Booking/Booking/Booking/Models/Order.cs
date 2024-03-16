using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public int? HomestayId { get; set; }
        public DateTime? Checkin { get; set; }
        public DateTime? Checkout { get; set; }
        public int? Status { get; set; }
        public int? UserBook { get; set; }

        public virtual HomeStay? Homestay { get; set; }
        public virtual Account? UserBookNavigation { get; set; }
    }
}
