namespace ClinicManagement.Core.Dto.AccountDto;

public class ChangePasswordDto
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
}