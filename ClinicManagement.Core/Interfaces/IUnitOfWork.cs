

using ClinicManagement.Core.Models;

namespace ClinicManagement.Core.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<User> Users { get; }
    IBaseRepository<Doctor> Doctors { get; }
    IBaseRepository<Appointment> Appointments { get; }
    Task CompleteAsync();
        
}