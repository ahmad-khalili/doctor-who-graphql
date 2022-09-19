using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public DoctorRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IEnumerable<Doctor> GetDoctors(int pageNumber, int pageSize)
    {
        var collection = _context.Doctors as IQueryable<Doctor>;
        
        var collectionToReturn =  collection.OrderBy(d => d.DoctorName)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();

        return collectionToReturn;
    }
}