using Booking.DTO;
using Booking.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Booking.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly bookingContext _context;
        public OrderRepository(bookingContext context)
        {
            _context = context;

        }
        public List<OrderShowDTO> getListOrder(int id, DateTime? checkin, DateTime? checkout)
        {
            List <OrderShowDTO> list = new List <OrderShowDTO> ();
            List<Order> orders = new List<Order> ();
            if (checkin == null && checkout == null)
            {
                orders = _context.Orders.Include(x => x.UserBookNavigation).Include(x => x.Homestay).Where(x => x.Homestay.Owner == id).ToList();
                
            }else if(checkout == null && checkin != null)
            {
                orders = _context.Orders.Include(x => x.UserBookNavigation).Include(x => x.Homestay).Where(x => x.Checkin >= checkin && x.Homestay.Owner == id).ToList();
                
            }else if(checkout != null && checkin == null)
            {
                orders = _context.Orders.Include(x => x.UserBookNavigation).Include(x => x.Homestay).Where(x => x.Checkout <= checkout && x.Homestay.Owner == id).ToList();
            }
            else
            {
                orders = _context.Orders.Include(x => x.UserBookNavigation).Include(x => x.Homestay).Where(x => x.Checkout <= checkout && x.Checkin >= checkin && x.Homestay.Owner == id).ToList();
            }

            foreach (var order in orders)
            {
                list.Add(new OrderShowDTO()
                {
                    nameHomeStay = order.Homestay.Name,
                    status = order.Status,
                    checkin = order.Checkin,
                    checkout = order.Checkout,
                    usernameBooking = order.UserBookNavigation.Username
                });
            }
            return list;
        }
    }
}
