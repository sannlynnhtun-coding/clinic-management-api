namespace ClinicManagement.Domain.Dto.AppointmentDto;

public class AppointmentDto
{
    public int DoctorId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
}