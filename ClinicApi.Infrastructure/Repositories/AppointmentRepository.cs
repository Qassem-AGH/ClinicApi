using ClinicApi.Domain.Entities;
using ClinicApi.Domain.Interfaces;
using ClinicApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Infrastructure.Repositories;

public class AppointmentRepository(AppDbContext db) : IRepository<Appointment>
{
    public async Task<Appointment?> GetByIdAsync(int id) =>
        await db.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .FirstOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<Appointment>> GetAllAsync() =>
        await db.Appointments
            .Include(a => a.Doctor)
            .Include(a => a.Patient)
            .ToListAsync();

    public async Task AddAsync(Appointment entity) => await db.Appointments.AddAsync(entity);
    public void Update(Appointment entity) => db.Appointments.Update(entity);
    public void Delete(Appointment entity) => db.Appointments.Remove(entity);
    public async Task SaveChangesAsync() => await db.SaveChangesAsync();
}