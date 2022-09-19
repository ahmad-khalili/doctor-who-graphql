using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface IEpisodeRepository
{
    Task<IEnumerable<Episode>> GetEpisodesAsync(int pageNumber, int pageSize);
}