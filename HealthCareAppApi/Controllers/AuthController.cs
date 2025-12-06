
using HealthCareAppApi.API.Services.Interfaces;
using HealthCareAppApi.DTOs.Request;
using Microsoft.AspNetCore.Mvc;

namespace HealthCareAppApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;
        private readonly IEmailService _emailService;
        public AuthController(IAuthService auth, IEmailService emailService)
        {
            _auth = auth;
            _emailService = emailService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequestDto request)
        {
            var token = await _auth.LoginAsync(request);
            if (token == null)
                return Unauthorized(new { message = "Invalid credentials" });

            return Ok(token);
        }


        //[HttpPost("forgot-password")]
        //public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        //{
        //    try
        //    {
        //        await _auth.ForgotPasswordAsync(request.Email);
        //        return Ok(new { message = "Password reset link sent to your email" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        //[HttpPost("reset-password")]
        //public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto request)
        //{
        //    try
        //    {
        //        await _auth.ResetPasswordAsync(request.Email, request.Token, request.NewPassword);
        //        return Ok(new { message = "Password has been reset successfully" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new { message = ex.Message });
        //    }
        //}

        //[HttpPost("send")]
        //public async Task<IActionResult> SendEmail([FromBody] EmailRequest request)
        //{
        //    await _emailService.SendEmailAsync(request);
        //    return Ok(new { Message = "Email sent successfully!" });
        //}
    }
}
