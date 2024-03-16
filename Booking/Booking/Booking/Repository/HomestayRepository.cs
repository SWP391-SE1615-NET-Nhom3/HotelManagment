using Booking.DTO;
using Booking.Models;
using Booking.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data;

namespace Booking.Repository
{
    public class HomestayRepository : IHomestayRepository
    {
        private readonly bookingContext _context;
        public HomestayRepository(bookingContext context)
        {
            _context = context;

        }
        public void change(int id,int status)
        {
            try
            {

                var home = _context.HomeStays.SingleOrDefault(x => x.Id == id);
                home.Status = status;
                _context.HomeStays.Update(home);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }
        public List<HomeStay> getAllHomeStay(int id)
        {
            var list = _context.HomeStays.Include(x => x.OwnerNavigation).Where(x => x.Owner == id).ToList();
            List<HomeStay> returnList = new();
            try
            {

                foreach (var item in list)
                {
                    HomeStay show = new HomeStay()
                    {
                        Id = item.Id,
                        Bathroom = item.Bathroom,
                        Bedroom = item.Bedroom,
                        Name = item.Name,
                        Status = item.Status,
                        PriceOneNight = item.PriceOneNight,
                        Detail = item.Detail,
                        Image = item.Image,
                        Address = item.Address
                    };
                    returnList.Add(show);
                }

            }
            catch (Exception ex)
            {

            }
            return returnList;
        }

        public List<HomeStay> getAllHomeStaybyAdmin()
        {
            var list = _context.HomeStays.Include(x => x.OwnerNavigation).ToList();
            List<HomeStay> returnList = new();
            try
            {

                foreach (var item in list)
                {
                    HomeStay show = new HomeStay()
                    {
                        Id = item.Id,
                        Bathroom = item.Bathroom,
                        Bedroom = item.Bedroom,
                        Name = item.Name,
                        Status = item.Status,
                        PriceOneNight = item.PriceOneNight,
                        Detail = item.Detail,
                        Image = item.Image,
                        Address = item.Address
                    };
                    returnList.Add(show);
                }

            }
            catch (Exception ex)
            {

            }
            return returnList;
        }
        public EditDTO getHomeStay(int id)
        {
            HomeStay homestay = _context.HomeStays.Include(x => x.Cate).Include(x => x.OwnerNavigation).Where(x => x.Id == id).SingleOrDefault();
            try
            {


                    return new EditDTO()
                    {
                        id = homestay.Id,
                        name = homestay.Name,
                        address = homestay.Address,
                        bedroom = homestay.Bedroom,
                        bathroom = homestay.Bathroom,
                        priceOneNight = homestay.PriceOneNight,
                        detail = homestay.Detail,
                        image = homestay.Image,
                        cate_id = homestay.CateId,
                        owner = homestay.OwnerNavigation.Username
                    };


            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public List<CategoryHomestay> GetCategories()
        {
            var list = _context.CategoryHomestays.ToList();
            List<CategoryHomestay> returnList = new();
            try
            {

                foreach (var item in list)
                {
                    CategoryHomestay show = new CategoryHomestay()
                    {
                        Id = item.Id,
                        Name = item.Name,
                    };
                    returnList.Add(show);
                }

            }
            catch (Exception ex)
            {

            }
            return returnList;
        }
        public void add(AddHomestayRequest request)
        {
            try
            {

                HomeStay home = new HomeStay();
                home.Name = request.name;
                home.Address = request.address;
                home.Bedroom = request.bedroom;
                home.Bathroom = request.bathroom;
                home.PriceOneNight = request.priceOneNight;
                home.Detail = request.detail;
                home.Image = request.image;
                home.CateId = request.cate_id;
                home.Owner = request.owner_id;
                home.Status = 0;
                _context.HomeStays.Add(home);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }

        public void edit(EditHomestayRequest request)
        {
            try
            {

                HomeStay home = _context.HomeStays.SingleOrDefault(x => x.Id == request.id);
                home.Name = request.name;
                home.Address = request.address;
                home.Bedroom = request.bedroom;
                home.Bathroom = request.bathroom;
                home.PriceOneNight = request.priceOneNight;
                home.Detail = request.detail;
                home.Image = request.image;
                home.CateId = request.cate_id;
                _context.HomeStays.Update(home);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }

        public StatisticDTO Statistic()
        {
            
            try
            {


                StatisticDTO dto = new StatisticDTO();
                dto.totalHomestay = _context.HomeStays.ToList().Count;
                dto.totalOrder = _context.Orders.ToList().Count;
                dto.totalAccount = _context.Accounts.ToList().Count;
                var orders = _context.Orders.Include(x => x.Homestay).ToList();
                double? total = 0;
                foreach (var item in orders)
                {
                    DateTime checkin = (DateTime) item.Checkin;
                    DateTime checkout =(DateTime) item.Checkout;
                    int day = (checkout - checkin).Days;
                    double? price = item.Homestay.PriceOneNight * day;
                    total += price;
                }
                dto.totalPrice = total;
                var groupedData = _context.Orders.GroupBy(x => x.HomestayId)
                                   .Select(group => new { ID = group.Key, Count = group.Count() });
                var topHomestays = groupedData.OrderByDescending(item => item.Count)
                                           .Take(5);
                List<HomestayDTO> l = new List<HomestayDTO>();
                foreach(var item in topHomestays)
                {
                    var home = _context.HomeStays.SingleOrDefault(x => x.Id == item.ID);
                    HomestayDTO h = new HomestayDTO()
                    {
                        name = home.Name,
                        totalBooking = item.Count
                    };
                    l.Add(h);
                }
                dto.list = l;
                return dto;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
