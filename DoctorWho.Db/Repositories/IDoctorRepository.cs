using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface IDoctorRepository
{
    Task<IEnumerable<Doctor>> GetDoctorsAsync(int pageNumber, int pageSize);
    Task<Doctor?> GetDoctorAsync(int doctorId);
    Task<int> UpsertDoctorAsync(Doctor doctor);
    void DeleteDoctor(Doctor doctor);
    Task<bool> SaveChangesAsync();
}