using Booking.Models;
using Booking.Request;

namespace Booking.Repository
{
    public interface IAccountRepository
    {
       
        Account GetAccountByUsernamePassword(string email, string password);

        Account GetAccountByEmail(string email);

        List<Account> getAllAccount();
        void ActionAccount(int account_id, int status);


        void UpdateProfile(UpdateProfileRequest request);
    }
}
