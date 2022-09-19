using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class CompanionRepository : ICompanionRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public CompanionRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task AddCompanionToEpisodeAsync(int episodeId, Companion companion)
    {
        var episode = await _context.Episodes.FirstOrDefaultAsync(e => e.EpisodeId.Equals(episodeId));

        var episodeCompanion = new EpisodeCompanion
        {
            Companion = companion,
            Episode = episode!
        };

        await _context.EpisodeCompanions.AddAsync(episodeCompanion);
    }
    
    public async Task<bool> EpisodeExistsAsync(int episodeId)
    {
        return await _context.Episodes.AnyAsync(e => e.EpisodeId.Equals(episodeId));
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}