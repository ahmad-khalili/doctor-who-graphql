using DoctorWho.Db.Entities;
using DoctorWho.Db.Services;

namespace DoctorWho.Db.Repositories;

public interface IEpisodeRepository
{
    Task<(IEnumerable<Episode>, PaginationMetadata)> GetEpisodesAsync(int pageNumber, int pageSize);
    Task AddEpisodeAsync(Episode episode);
    Task<bool> AuthorExistsAsync(int authorId);
    Task<bool> DoctorExistsAsync(int doctorId);
    Task<Episode?> GetEpisodeAsync(int episodeId);
    Task<bool> SaveChangesAsync();
}