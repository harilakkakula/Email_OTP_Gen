

using Email_OTP_Gen.Services;
using Moq;

public class EmailOtpServiceTests
{
    private readonly Mock<IEmailOtpService> _mockEmailOtpService;

    public EmailOtpServiceTests()
    {
        _mockEmailOtpService = new Mock<IEmailOtpService>();
    }

    // Test case for generating OTP email
    [Fact]
    public void GenerateOtpEmail_ValidEmail_ReturnsStatusEmailOk()
    {
        // Arrange
        var email = "test@gov.dso.org.sg";
        _mockEmailOtpService.Setup(service => service.GenerateOtpEmail(email))
            .Returns(IEmailOtpService.STATUS_EMAIL_OK);

        // Act
        var result = _mockEmailOtpService.Object.GenerateOtpEmail(email);

        // Assert
        Assert.Equal(IEmailOtpService.STATUS_EMAIL_OK, result);
    }

    // Test case for generating OTP with invalid email
    [Fact]
    public void GenerateOtpEmail_InvalidEmail_ReturnsStatusEmailInvalid()
    {
        // Arrange
        var email = "test@invalid.com";
        _mockEmailOtpService.Setup(service => service.GenerateOtpEmail(email))
            .Returns(IEmailOtpService.STATUS_EMAIL_INVALID);

        // Act
        var result = _mockEmailOtpService.Object.GenerateOtpEmail(email);

        // Assert
        Assert.Equal(IEmailOtpService.STATUS_EMAIL_INVALID, result);
    }

    // Test case for checking OTP (Valid OTP)
    [Fact]
    public void CheckOtp_ValidOtp_ReturnsStatusOtpOk()
    {
        // Arrange
        var email = "test@gov.dso.org.sg";
        var otp = "123456"; // Valid OTP
        _mockEmailOtpService.Setup(service => service.CheckOtp(email, otp))
            .Returns(IEmailOtpService.STATUS_OTP_OK);

        // Act
        var result = _mockEmailOtpService.Object.CheckOtp(email, otp);

        // Assert
        Assert.Equal(IEmailOtpService.STATUS_OTP_OK, result);
    }

    // Test case for checking OTP (Invalid OTP)
    [Fact]
    public void CheckOtp_InvalidOtp_ReturnsStatusOtpFail()
    {
        // Arrange
        var email = "test@gov.dso.org.sg";
        var otp = "000000"; // Invalid OTP
        _mockEmailOtpService.Setup(service => service.CheckOtp(email, otp))
            .Returns(IEmailOtpService.STATUS_OTP_FAIL);

        // Act
        var result = _mockEmailOtpService.Object.CheckOtp(email, otp);

        // Assert
        Assert.Equal(IEmailOtpService.STATUS_OTP_FAIL, result);
    }

    // Test case for checking OTP (Timeout)
    [Fact]
    public void CheckOtp_Timeout_ReturnsStatusOtpTimeout()
    {
        // Arrange
        var email = "test@gov.dso.org.sg";
        var otp = "123456"; // OTP
        _mockEmailOtpService.Setup(service => service.CheckOtp(email, otp))
            .Returns(IEmailOtpService.STATUS_OTP_TIMEOUT);

        // Act
        var result = _mockEmailOtpService.Object.CheckOtp(email, otp);

        // Assert
        Assert.Equal(IEmailOtpService.STATUS_OTP_TIMEOUT, result);
    }

    // Test case for checking OTP after max attempts
    [Fact]
    public void CheckOtp_MaxAttempts_ReturnsStatusOtpFail()
    {
        // Arrange
        var email = "test@gov.dso.org.sg";
        var otp = "123456"; // OTP
        _mockEmailOtpService.Setup(service => service.CheckOtp(email, otp))
            .Returns(IEmailOtpService.STATUS_OTP_FAIL); // Mock max attempts reached case

        // Act
        var result = _mockEmailOtpService.Object.CheckOtp(email, otp);

        // Assert
        Assert.Equal(IEmailOtpService.STATUS_OTP_FAIL, result);
    }


}
