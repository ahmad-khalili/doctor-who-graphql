using DoctorWho.Db.Entities;
using DoctorWho.Db.Services;

namespace DoctorWho.Db.Repositories;

public interface IDoctorRepository
{
    Task<(IEnumerable<Doctor>, PaginationMetadata)> GetDoctorsAsync(int pageNumber, int pageSize);
    Task<Doctor?> GetDoctorAsync(int doctorId);
    Task<int> UpsertDoctor(Doctor doctor);
    void DeleteDoctor(Doctor doctor);
    Task<bool> SaveChangesAsync();
}