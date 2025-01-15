using ClinicManagement.Core.Dto.UserDto;
using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.InterfaceServices;
using ClinicManagement.Core.Models;
using ClinicManagement.Core.ResponseModel;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinic_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUsers()
        {
            var users=await _userServices.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser (int id) 
        {
            return Ok(await _userServices.DeleteUserAsync(id));
        }
    }
}
