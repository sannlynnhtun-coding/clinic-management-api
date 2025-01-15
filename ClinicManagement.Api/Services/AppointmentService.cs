namespace Clinic_Management.Services;

public class AppointmentService: IAppointmentService
{
    private readonly IUnitOfWork _unitOfWork;


    public AppointmentService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public async Task<ResponseModel<IEnumerable<AppointmentDto>>> GetAllAppointmentsAsync()
    {
        var appointments = await _unitOfWork.Appointments.GetAllAsync();
        var appointmentDtos = appointments.Adapt<IEnumerable<AppointmentDto>>();
        return ResponseModel<IEnumerable<AppointmentDto>>.CreateSuccessResponse(appointmentDtos);
    }

    public async Task<ResponseModel<AppointmentDto>> GetAppointmentByIdAsync(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
            return ResponseModel<AppointmentDto>.CreateErrorResponse("Appointment not found.");

        var appointmentDto = appointment.Adapt<AppointmentDto>();
        return ResponseModel<AppointmentDto>.CreateSuccessResponse(appointmentDto);
    }

    public async Task<ResponseModel<AppointmentDto>> AddAppointmentAsync(AppointmentDto appointmentDto)
    {
        var appointment = appointmentDto.Adapt<Appointment>();
        await _unitOfWork.Appointments.AddAsync(appointment);
        await _unitOfWork.CompleteAsync();
        return ResponseModel<AppointmentDto>.CreateSuccessResponse(appointmentDto, "Appointment added successfully.");
    }

    public async Task<ResponseModel<AppointmentDto>> UpdateAppointmentStatusAsync(int id, string status)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
            return ResponseModel<AppointmentDto>.CreateErrorResponse("Appointment not found.");

        appointment.Status = status;
        _unitOfWork.Appointments.Update(appointment);
        await _unitOfWork.CompleteAsync();

        var appointmentDto = appointment.Adapt<AppointmentDto>();
        return ResponseModel<AppointmentDto>.CreateSuccessResponse(appointmentDto, "Appointment status updated successfully.");
    }

    public async Task<ResponseModel<bool>> DeleteAppointmentAsync(int id)
    {
        var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
        if (appointment == null)
            return ResponseModel<bool>.CreateErrorResponse("Appointment not found.");

        _unitOfWork.Appointments.Delete(appointment);
        await _unitOfWork.CompleteAsync();
        return ResponseModel<bool>.CreateSuccessResponse(true, "Appointment deleted successfully.");
    }
}