using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface IDoctorRepository
{
    IEnumerable<Doctor> GetDoctors(int pageNumber, int pageSize);
    Task<int> UpsertDoctorAsync(Doctor doctor);
}