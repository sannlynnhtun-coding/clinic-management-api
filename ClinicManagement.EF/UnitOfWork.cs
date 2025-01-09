using ClinicManagement.Core.Interfaces;
using ClinicManagement.Core.Models;
using System;

namespace ClinicManagement.EF
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Users = new BaseRepository<User>(context);
            Doctors = new BaseRepository<Doctor>(context);
            Appointments = new BaseRepository<Appointment>(context);
        }

        public IBaseRepository<User> Users { get; private set; }
        public IBaseRepository<Doctor> Doctors { get; private set; }
        public IBaseRepository<Appointment> Appointments { get; private set; }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
