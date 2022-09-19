using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public interface ICompanionRepository
{
    Task AddCompanionToEpisodeAsync(int episodeId, Companion companion);
    Task<bool> EpisodeExistsAsync(int episodeId);
    Task<bool> SaveChangesAsync();
}