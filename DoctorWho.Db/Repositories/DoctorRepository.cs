using DoctorWho.Db.Entities;
using DoctorWho.Db.Services;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public DoctorRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public void AddDoctor(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        _context.SaveChanges();
    }

    public void ModifyDoctorName(Doctor doctor, string newName)
    {
        doctor.DoctorName = newName;
        _context.SaveChanges();
    }
    
    public void ModifyDoctorNumber(Doctor doctor, int newNumber)
    {
        doctor.DoctorNumber = newNumber;
        _context.SaveChanges();
    }
    
    public void ModifyDoctorBirth(Doctor doctor, DateTime newBirth)
    {
        doctor.BirthDate = newBirth;
        _context.SaveChanges();
    }
    
    public void ModifyDoctorFirstEpisode(Doctor doctor, DateTime newDate)
    {
        doctor.FirstEpisodeDate = newDate;
        _context.SaveChanges();
    }
    public void ModifyDoctorLastEpisode(Doctor doctor, DateTime newDate)
    {
        doctor.LastEpisodeDate = newDate;
        _context.SaveChanges();
    }

    public void DeleteDoctor(Doctor doctor)
    {
        _context.Doctors.Remove(doctor);
    }

    public ICollection<Doctor> GetAll()
    {
        return _context.Doctors.ToList();
    }

    public async Task<(IEnumerable<Doctor>, PaginationMetadata)> GetDoctorsAsync(int pageNumber, int pageSize)
    {
        var collection = _context.Doctors as IQueryable<Doctor>;

        var totalItemCount = await collection.CountAsync();

        var paginationMetadata = new PaginationMetadata(totalItemCount, pageSize, pageNumber);

        var collectionToReturn = await collection.OrderBy(d => d.DoctorName)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        return (collectionToReturn, paginationMetadata);
    }

    public async Task<Doctor?> GetDoctorAsync(int doctorId)
    {
        return await _context.Doctors.FirstOrDefaultAsync(d => d.DoctorId.Equals(doctorId));
    }

    private async Task<int> GetDoctorId(Doctor doctor)
    {
        var queriedDoctor = await _context.Doctors
            .FirstOrDefaultAsync(d => d.DoctorNumber.Equals(doctor.DoctorNumber));
        
        if (queriedDoctor == default)
            throw new Exception("Doctor not found!");

        return queriedDoctor.DoctorId;
    }

    public async Task<int> UpsertDoctor(Doctor doctor)
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
        
        var doctorId = await GetDoctorId(doctor);

        return doctorId;
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}