using DoctorWho.Db.Entities;

namespace DoctorWho.Db.Repositories;

public class EpisodeCompanionRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public EpisodeCompanionRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public void AddCompanionToEpisode(Companion companion, Episode episode)
    {
        if (!_context.Companions.Contains(companion)) throw new ArgumentException("Companion doesn't exist!");
        if (!_context.Episodes.Contains(episode)) throw new ArgumentException("Episode doesn't exist!");

        var newEpisodeCompanion = new EpisodeCompanion
        {
            CompanionId = companion.CompanionId,
            EpisodeId = episode.EpisodeId
        };

        _context.EpisodeCompanions.Add(newEpisodeCompanion);
    }
}