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

    private async Task<int> GetDoctorIdAsync(Doctor doctor)
    {
        var queriedDoctor = await _context.Doctors
            .FirstOrDefaultAsync(d => d.DoctorNumber.Equals(doctor.DoctorNumber));
        
        if (queriedDoctor == default)
            throw new Exception("Doctor not found!");

        return queriedDoctor.DoctorId;
    }

    public async Task<int> UpsertDoctorAsync(Doctor doctor)
    {
        await _context.Doctors.Upsert(doctor)
            .On(d => d.DoctorNumber)
            .WhenMatched(d => new Doctor
            {
                DoctorName = doctor.DoctorName,
                DoctorNumber = doctor.DoctorNumber,
                BirthDate = doctor.BirthDate,
                FirstEpisodeDate = doctor.FirstEpisodeDate,
                LastEpisodeDate = doctor.LastEpisodeDate,
            }).RunAsync();
        
        var doctorId = await GetDoctorIdAsync(doctor);

        return doctorId;
    }

    public async Task<Doctor?> GetDoctorAsync(int doctorId)
    {
        return await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId.Equals(doctorId));
    }

    public void DeleteDoctor(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}