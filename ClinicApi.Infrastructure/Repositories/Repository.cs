using ClinicApi.Domain.Interfaces;
using ClinicApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ClinicApi.Infrastructure.Repositories;

public class Repository<T>(AppDbContext db) : IRepository<T> where T : class
{
    private readonly DbSet<T> _set = db.Set<T>();

    public async Task<T?> GetByIdAsync(int id) => await _set.FindAsync(id);
    public async Task<IEnumerable<T>> GetAllAsync() => await _set.ToListAsync();
    public async Task AddAsync(T entity) => await _set.AddAsync(entity);
    public void Update(T entity) => _set.Update(entity);
    public void Delete(T entity) => _set.Remove(entity);
    public async Task SaveChangesAsync() => await db.SaveChangesAsync();
}