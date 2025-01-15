using ClinicManagement.Domain.Dto.AppointmentDto;
using ClinicManagement.Domain.ResponseModel;

namespace ClinicManagement.Domain.InterfaceServices;

public interface IAppointmentService
{
    Task<ResponseModel<IEnumerable<AppointmentDto>>> GetAllAppointmentsAsync();
    Task<ResponseModel<AppointmentDto>> GetAppointmentByIdAsync(int id);
    Task<ResponseModel<AppointmentDto>> AddAppointmentAsync(AppointmentDto appointmentDto);
    Task<ResponseModel<AppointmentDto>> UpdateAppointmentStatusAsync(int id, string status);
    Task<ResponseModel<bool>> DeleteAppointmentAsync(int id);
}