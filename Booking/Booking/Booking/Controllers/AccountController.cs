using Booking.Repository;
using Booking.Request;
using Booking.Token;
using Booking.Validate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Booking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IManageToken _manageToken;
        public AccountController(IAccountRepository _accountRepository, IManageToken manageToken)
        {
            accountRepository = _accountRepository;
            _manageToken = manageToken;
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest userRequest)
        {
            if (accountRepository.GetAccountByUsernamePassword(userRequest.email, userRequest.password) == null)
            {
                return Ok("Login Fail");
            }
            else
            {
                var user = accountRepository.GetAccountByUsernamePassword(userRequest.email, userRequest.password);
                var accessToken = _manageToken.generateToken(userRequest);


                return Ok(accessToken);
            }

        }

        [HttpGet("ManageAccountAdmin")]
        [Authorize(Roles = "1")]
        public IActionResult Get()
        {
            try
            {

                return Ok(accountRepository.getAllAccount());
            }
            catch (Exception ex)
            {

                return BadRequest(null);
            }
        }
        [HttpGet("{email}")]
        [Authorize(Roles = "3")]
        public IActionResult Profile(String email)
        {
            try
            {

                return Ok(accountRepository.GetAccountByEmail(email));
            }
            catch (Exception ex)
            {

                return BadRequest(null);
            }
        }

        [HttpPut("ActionAccount")]
        [Authorize(Roles = "1")]
        public void ActionAccount([FromBody] AccountManage request)
        {
            try
            {
                accountRepository.ActionAccount(request.account_id, request.status);
            }
            catch (Exception ex)
            {

            }
        }

       


        [HttpPut("UpdateProfile")]
        [Authorize(Roles = "3")]
        public IActionResult UpdateProfile([FromBody] UpdateProfileRequest request)
        {

            try
            {
                List<string> errors = new AccountValidate(accountRepository).ValidateUpdateProfileRequest(request);
                if (errors.Count > 0)
                {
                    return BadRequest(errors);
                }
                else
                {
                    accountRepository.UpdateProfile(request);
                    return Ok(errors);
                }

            }
            catch (Exception ex)
            {
                List<string> errors = new List<string>();
                errors.Add(ex.Message);
                return BadRequest(errors);
            }
        }
    }
}
