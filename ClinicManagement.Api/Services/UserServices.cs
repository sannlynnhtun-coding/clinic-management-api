namespace Clinic_Management.Services;

public class UserServices : IUserServices
{
    private readonly IUnitOfWork _unitOfWork;


    public UserServices(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<IEnumerable<User>>> GetAllUsersAsync()
    {
        var users = await _unitOfWork.Users.GetAllAsync();
        return ResponseModel<IEnumerable<User>>.CreateSuccessResponse(users);
    }

    public async Task<ResponseModel<bool>> DeleteUserAsync(int id)
    {
        var user = await _unitOfWork.Users.GetByIdAsync(id);
        if (user == null)
        {
            return ResponseModel<bool>.CreateErrorResponse("User not found.");
        }

        _unitOfWork.Users.Delete(user);
        await _unitOfWork.CompleteAsync();
        return ResponseModel<bool>.CreateSuccessResponse(true, "User deleted successfully.");
    }
}