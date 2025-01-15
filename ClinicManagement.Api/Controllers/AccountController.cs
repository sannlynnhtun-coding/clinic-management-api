namespace Clinic_Management.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IConfiguration _configuration;

    public AccountController(IUnitOfWork unitOfWork, IConfiguration configuration)
    {
        _unitOfWork = unitOfWork;
        _configuration = configuration;
    }

    // 1. Register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        // تحقق إذا كان البريد الإلكتروني مستخدمًا بالفعل
        var existingUser = (await _unitOfWork.Users.GetAllAsync())
            .FirstOrDefault(u => u.Email == registerDto.Email);

        if (existingUser != null)
        {
            return BadRequest(ResponseModel<string>.CreateErrorResponse("Email is already in use."));
        }

        // إنشاء المستخدم الجديد
        var newUser = new User
        {
            Name = registerDto.Name,
            Email = registerDto.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password), // تشفير كلمة المرور
            Role = "Patient" // الافتراضي
        };

        await _unitOfWork.Users.AddAsync(newUser);
        await _unitOfWork.CompleteAsync();

        return Ok(ResponseModel<string>.CreateSuccessResponse(null, "User registered successfully."));
    }

    // 2. Login
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        var user = (await _unitOfWork.Users.GetAllAsync())
            .FirstOrDefault(u => u.Email == loginDto.Email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
        {
            return Unauthorized(ResponseModel<string>.CreateErrorResponse("Invalid credentials."));
        }

        // إنشاء التوكن JWT
        var token = GenerateJwtToken(user);

        return Ok(ResponseModel<string>.CreateSuccessResponse(token, "Login successful."));
    }

    // 3. Change Password
    [HttpPut("change-password")]
    [Authorize]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto changePasswordDto)
    {
        var email = User.FindFirst(ClaimTypes.Name)?.Value;

        var user = (await _unitOfWork.Users.GetAllAsync())
            .FirstOrDefault(u => u.Email == email);

        if (user == null)
        {
            return Unauthorized(ResponseModel<string>.CreateErrorResponse("User not found."));
        }

        if (!BCrypt.Net.BCrypt.Verify(changePasswordDto.CurrentPassword, user.Password))
        {
            return BadRequest(ResponseModel<string>.CreateErrorResponse("Current password is incorrect."));
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordDto.NewPassword);
        _unitOfWork.Users.Update(user);
        await _unitOfWork.CompleteAsync();

        return Ok(ResponseModel<string>.CreateSuccessResponse(null, "Password updated successfully."));
    }

    // Helper to generate JWT Token
    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, user.Email),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(1),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}