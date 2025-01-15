using ClinicManagement.Core.Models;
using ClinicManagement.Core.ResponseModel;

namespace ClinicManagement.Core.InterfaceServices;

public interface IUserServices
{
    Task<ResponseModel<IEnumerable<User>>> GetAllUsersAsync();
    Task<ResponseModel<bool>> DeleteUserAsync(int id);
}