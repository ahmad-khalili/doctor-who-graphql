using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface IEpisodeRepository
{
    Task<IEnumerable<Episode>> GetEpisodesAsync(int pageNumber, int pageSize);
    Task AddEpisodeAsync(Episode episode);
    Task<bool> AuthorExistsAsync(int authorId);
    Task<bool> DoctorExistsAsync(int doctorId);
    Task<bool> SaveChangesAsync();

}