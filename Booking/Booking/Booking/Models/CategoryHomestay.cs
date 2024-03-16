using System;
using System.Collections.Generic;

namespace Booking.Models
{
    public partial class CategoryHomestay
    {
        public CategoryHomestay()
        {
            HomeStays = new HashSet<HomeStay>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<HomeStay> HomeStays { get; set; }
    }
}
