using ClinicManagement.Domain.Models;
using ClinicManagement.Domain.ResponseModel;

namespace ClinicManagement.Domain.InterfaceServices;

public interface IDoctorsService
{

    Task<ResponseModel<IEnumerable<Doctor>>> GetAllDoctorsAsync();
    Task<ResponseModel<Doctor>> GetDoctorByIdAsync(int id);
    Task<ResponseModel<bool>> AddDoctorAsync(Doctor doctor);
    Task<ResponseModel<bool>> UpdateSpecializationAsync(int id, string specialization);
    Task<ResponseModel<bool>> DeleteDoctorAsync(int id);
}