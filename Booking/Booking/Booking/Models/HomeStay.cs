using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class HomeStay
    {
        public HomeStay()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? Bedroom { get; set; }
        public int? Bathroom { get; set; }
        public double? PriceOneNight { get; set; }
        public string? Detail { get; set; }
        public string? Image { get; set; }
        public int? Owner { get; set; }
        public int? CateId { get; set; }
        public int? Status { get; set; }

        public virtual CategoryHomestay? Cate { get; set; }
        public virtual Account? OwnerNavigation { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
