namespace Email_OTP_Gen.Services
{
    public interface IEmailOtpService
    {
        int GenerateOtpEmail(string userEmail);
        int CheckOtp(string userEmail, string otp);

        // Keep this as in separete Constant file
        public const int STATUS_EMAIL_OK = 1;
        public const int STATUS_EMAIL_FAIL = 2;
        public const int STATUS_EMAIL_INVALID = 3;
        public const int STATUS_OTP_OK = 4;
        public const int STATUS_OTP_FAIL = 5;
        public const int STATUS_OTP_TIMEOUT = 6;
    }
}
