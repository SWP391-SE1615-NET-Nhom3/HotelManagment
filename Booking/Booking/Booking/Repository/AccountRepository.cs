using Booking.Models;
using Booking.Request;

namespace Booking.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly bookingContext _context;
        public AccountRepository(bookingContext context)
        {
            _context = context;

        }
        public void ActionAccount(int account_id, int status)
        {
            try
            {
                var account = _context.Accounts.SingleOrDefault(x => x.Id == account_id);
                if (account == null)
                {
                    return;
                }
                else
                {
                    account.Status = status;
                }
                _context.Accounts.Update(account);
                _context.SaveChanges();




            }
            catch (Exception ex)
            {

            }
        }

        public Account GetAccountByEmail(string email)
        {
            try
            {
                return _context.Accounts.SingleOrDefault(x => x.Email.Equals(email));

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Account GetAccountByUsernamePassword(string email, string password)
        {
            try
            {
                return _context.Accounts.SingleOrDefault(x => x.Email.Equals(email) && x.Password.Equals(password));

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<Account> getAllAccount()
        {
            var list = _context.Accounts.ToList();
            List<Account> returnList = new();
            try
            {

                foreach (var item in list)
                {
                    Account show = new Account()
                    {
                        Id = item.Id,
                        Username = item.Username,
                        Email = item.Email,
                        RoleId = item.RoleId,
                        Status = item.Status,
                        Phone = item.Phone,
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

        public void UpdateProfile(UpdateProfileRequest request)
        {
            try
            {

                var user = _context.Accounts.SingleOrDefault(x => x.Email.Equals(request.email));
                user.Address = request.address;
                user.Phone = request.phone;
                user.Username = request.name;
                _context.Accounts.Update(user);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
        }
    }
}
