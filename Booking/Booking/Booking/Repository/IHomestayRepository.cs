using Booking.DTO;
using Booking.Models;
using Booking.Request;

namespace Booking.Repository
{
    public interface IHomestayRepository
    {
        List<HomeStay> getAllHomeStay(int id);
        List<HomeStay> getAllHomeStaybyAdmin();

        void change(int id,int status);

        List<CategoryHomestay> GetCategories();

        void add(AddHomestayRequest request);

        void edit(EditHomestayRequest request);

        EditDTO getHomeStay(int id);

        StatisticDTO Statistic();
    }
}
