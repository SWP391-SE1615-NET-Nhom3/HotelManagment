using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class Account
    {
        public Account()
        {
            HomeStays = new HashSet<HomeStay>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int? RoleId { get; set; }
        public string? Username { get; set; }
        public int? Status { get; set; }

        public virtual ICollection<HomeStay> HomeStays { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
