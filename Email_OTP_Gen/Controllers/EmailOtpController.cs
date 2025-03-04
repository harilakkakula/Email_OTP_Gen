using Email_OTP_Gen.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Email_OTP_Gen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailOtpController : ControllerBase
    {
        private readonly IEmailOtpService _emailOtpService;

        public EmailOtpController(IEmailOtpService emailOtpService)
        {
            _emailOtpService = emailOtpService;
        }

        // Endpoint to generate OTP and send it via email
        [HttpPost("generate")]
        public IActionResult GenerateOtp([FromBody] EmailRequest emailRequest)
        {
            var result = _emailOtpService.GenerateOtpEmail(emailRequest.Email!);
            switch (result)
            {
                case IEmailOtpService.STATUS_EMAIL_OK:
                    return Ok("OTP sent successfully!");
                case IEmailOtpService.STATUS_EMAIL_FAIL:
                    return StatusCode(500, "Failed to send OTP email.");
                case IEmailOtpService.STATUS_EMAIL_INVALID:
                    return BadRequest("Invalid email address.");
                default:
                    return StatusCode(500, "An unexpected error occurred.");
            }
        }

        // Endpoint to verify OTP entered by the user
        [HttpPost("verify")]
        public IActionResult VerifyOtp([FromBody] OtpVerificationRequest otpRequest)
        {
            var result = _emailOtpService.CheckOtp(otpRequest.Email!, otpRequest.Otp!);
            switch (result)
            {
                case IEmailOtpService.STATUS_OTP_OK:
                    return Ok("OTP verified successfully!");
                case IEmailOtpService.STATUS_OTP_FAIL:
                    return BadRequest("Incorrect OTP or failed after 10 attempts.");
                case IEmailOtpService.STATUS_OTP_TIMEOUT:
                    return BadRequest("OTP expired.");
                default:
                    return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }

    // DTO modles
    public class EmailRequest
    {
        // Here We can have fluent Validations to validate the regex Email format and return back the status as Invalid if user enter the Incorrect email format
        public string? Email { get; set; }
    }

    public class OtpVerificationRequest
    {
        // Here We can have fluent Validations to validate the regex Email format and return back the status as Invalid if user enter the Incorrect email format
        // Making this as Mandatory 
        [Required]
        public string? Email { get; set; }
        
        [Required]
        // The User Eneterd Input has minimum and Maximu length of 6 charecters. other wise attribute will throw error as OTP min and max length was not matched.
        [MinLength(6)]
        [MaxLength(6)]
        public string? Otp { get; set; }
    }
}