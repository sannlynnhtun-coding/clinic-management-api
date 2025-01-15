using ClinicManagement.Domain.Models;

namespace ClinicManagement.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<User> Users { get; }
    IBaseRepository<Doctor> Doctors { get; }
    IBaseRepository<Appointment> Appointments { get; }
    Task CompleteAsync();
        
}