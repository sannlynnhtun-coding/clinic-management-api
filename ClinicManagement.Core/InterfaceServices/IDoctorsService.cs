using ClinicManagement.Core.Models;
using ClinicManagement.Core.ResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicManagement.Core.InterfaceServices
{
    public interface IDoctorsService
    {

        Task<ResponseModel<IEnumerable<Doctor>>> GetAllDoctorsAsync();
        Task<ResponseModel<Doctor>> GetDoctorByIdAsync(int id);
        Task<ResponseModel<bool>> AddDoctorAsync(Doctor doctor);
        Task<ResponseModel<bool>> UpdateSpecializationAsync(int id, string specialization);
        Task<ResponseModel<bool>> DeleteDoctorAsync(int id);
    }
}

