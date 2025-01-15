using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.ResponseModel;

namespace ClinicManagement.Domain.InterfaceServices;

public interface IUserServices
{
    Task<ResponseModel<IEnumerable<User>>> GetAllUsersAsync();
    Task<ResponseModel<bool>> DeleteUserAsync(int id);
}