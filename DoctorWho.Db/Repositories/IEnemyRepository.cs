using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface IEnemyRepository
{
    Task AddEnemyToEpisodeAsync(int episodeId, Enemy enemy);
    Task<bool> EpisodeExistsAsync(int episodeId);
    Task<bool> SaveChangesAsync();
}