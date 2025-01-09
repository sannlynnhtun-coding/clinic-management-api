using ClinicManagement.Core.Dto.AppointmentDto;
using ClinicManagement.Core.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.InterfaceServices
{
    public interface IAppointmentService
    {
        Task<ResponseModel<IEnumerable<AppointmentDto>>> GetAllAppointmentsAsync();
        Task<ResponseModel<AppointmentDto>> GetAppointmentByIdAsync(int id);
        Task<ResponseModel<AppointmentDto>> AddAppointmentAsync(AppointmentDto appointmentDto);
        Task<ResponseModel<AppointmentDto>> UpdateAppointmentStatusAsync(int id, string status);
        Task<ResponseModel<bool>> DeleteAppointmentAsync(int id);
    }
}
