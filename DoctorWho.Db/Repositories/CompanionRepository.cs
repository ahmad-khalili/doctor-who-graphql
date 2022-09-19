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
    
    public Companion GetCompanionById(int companionId)
    {
        var companion = _context.Companions.FirstOrDefault(c => c.CompanionId == companionId);
        if (companion == default)
            throw new Exception($"Companion with Id({companionId}) was not found!");
        return companion;
    }
    
    public void AddCompanion(Companion companion)
    {
        _context.Companions.Add(companion);
        _context.SaveChanges();
    }

    public void ModifyCompanionName(Companion companion, string newName)
    {
        companion.CompanionName = newName;
        _context.SaveChanges();
    }
    
    public void ModifyCompanionActor(Companion companion, string newActorName)
    {
        companion.WhoPlayed = newActorName;
        _context.SaveChanges();
    }

    public void DeleteCompanion(int companionId)
    {
        var companionToDelete = _context.Companions.FirstOrDefault(c => c.CompanionId.Equals(companionId));

        if (companionToDelete == default)
            throw new Exception($"Companion with id {companionId} not found!");
        
        _context.Companions.Remove(companionToDelete);
        _context.SaveChanges();
    }
    
    public string? PrintCompanionsForEpisode(int episodeId)
    {
        var companions = _context.Episodes.Select(e => _context.GetCompanions(episodeId)).FirstOrDefault();
        return companions;
    }

    public async Task<bool> EpisodeExistsAsync(int episodeId)
    {
        return await _context.Episodes.AnyAsync(e => e.EpisodeId.Equals(episodeId));
    }

    public async Task AddCompanionToEpisodeAsync(int episodeId, Companion companion)
    {
        var episode = await _context.Episodes
            .FirstOrDefaultAsync(e => e.EpisodeId.Equals(episodeId));

        var episodeCompanionToAdd = new EpisodeCompanion
        {
            Episode = episode!,
            Companion = companion
        };

        await _context.EpisodeCompanions.AddAsync(episodeCompanionToAdd);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >= 0;
    }
}