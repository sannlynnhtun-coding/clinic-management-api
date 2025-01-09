using ClinicManagement.Core.Dto.UserDto;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.InterfaceServices
{
    public interface IUserServices
    {
        Task<ResponseModel<IEnumerable<User>>> GetAllUsersAsync();
        Task<ResponseModel<bool>> DeleteUserAsync(int id);
    }
}
