namespace ClinicManagement.Domain.Models;

public class Appointment
{
    public int Id { get; set; }
    public int DoctorId { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } // e.g., Confirmed, Canceled
    public Doctor Doctor { get; set; }
    public User User { get; set; }
}