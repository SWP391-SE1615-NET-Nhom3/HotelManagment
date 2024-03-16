using Booking.DTO;

namespace Booking.Repository
{
    public interface IOrderRepository
    {

        List<OrderShowDTO> getListOrder(int id,DateTime? checkin,DateTime? checkout);
    }
}
