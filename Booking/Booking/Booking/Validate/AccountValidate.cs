using Booking.Repository;
using Booking.Request;
using System.Text.RegularExpressions;

namespace Booking.Validate
{
    public class AccountValidate
    {
        private readonly IAccountRepository _accountRepository;
        public AccountValidate(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        public Boolean ValidateExistEmail(String email)
        {
            var accounts = _accountRepository.getAllAccount();
            foreach (var account in accounts)
            {
                if (email.ToUpper().Equals(account.Email.ToUpper()))
                {
                    return false;
                }
            }
            return true;
        }
        public Boolean ValidatePhone(String phone)
        {
            Regex regex = new Regex(@"^\d{10}$");
            return regex.IsMatch(phone);
        }
        public Boolean ValidateLength(String input)
        {
            if (input.Length >= 50 || string.IsNullOrEmpty(input))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        public List<string> ValidateUpdateProfileRequest(UpdateProfileRequest request)
        {
            List<string> errors = new List<string>();
            if (!ValidatePhone(request.phone))
            {
                errors.Add("Phone contains exact of 10 digit characters");
            }
            if (!ValidateLength(request.address) || !ValidateLength(request.name))
            {
                errors.Add("Address,Name must not empty and not over 50 characters");
            }
            return errors;
        }

      
    }
}
