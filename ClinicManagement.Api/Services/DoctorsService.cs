namespace Clinic_Management.Services;

public class DoctorsService: IDoctorsService
{
    private readonly IUnitOfWork _unitOfWork;

    public DoctorsService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseModel<IEnumerable<Doctor>>> GetAllDoctorsAsync()
    {
        var doctors = await _unitOfWork.Doctors.GetAllAsync();
        return ResponseModel<IEnumerable<Doctor>>.CreateSuccessResponse(doctors);
    }

    public async Task<ResponseModel<Doctor>> GetDoctorByIdAsync(int id)
    {
        var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
        if (doctor == null)
        {
            return ResponseModel<Doctor>.CreateErrorResponse("Doctor not found.");
        }
        return ResponseModel<Doctor>.CreateSuccessResponse(doctor);
    }

    public async Task<ResponseModel<bool>> AddDoctorAsync(Doctor doctor)
    {
        await _unitOfWork.Doctors.AddAsync(doctor);
        await _unitOfWork.CompleteAsync();
        return ResponseModel<bool>.CreateSuccessResponse(true, "Doctor added successfully.");
    }

    public async Task<ResponseModel<bool>> UpdateSpecializationAsync(int id, string specialization)
    {
        var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
        if (doctor == null)
        {
            return ResponseModel<bool>.CreateErrorResponse("Doctor not found.");
        }

        doctor.Specialization = specialization;
        _unitOfWork.Doctors.Update(doctor);
        await _unitOfWork.CompleteAsync();
        return ResponseModel<bool>.CreateSuccessResponse(true, "Specialization updated successfully.");
    }

    public async Task<ResponseModel<bool>> DeleteDoctorAsync(int id)
    {
        var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
        if (doctor == null)
        {
            return ResponseModel<bool>.CreateErrorResponse("Doctor not found.");
        }

        _unitOfWork.Doctors.Delete(doctor);
        await _unitOfWork.CompleteAsync();
        return ResponseModel<bool>.CreateSuccessResponse(true, "Doctor deleted successfully.");
    }
}