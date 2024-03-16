using Booking.Request;
using System.Security.Claims;

namespace Booking.Token
{
    public interface IManageToken
    {
        public String generateToken(LoginRequest userRequest);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
