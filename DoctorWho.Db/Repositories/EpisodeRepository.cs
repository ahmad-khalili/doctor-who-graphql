using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db.Repositories;

public class EpisodeRepository : IEpisodeRepository
{
    private readonly DoctorWhoCoreDbContext _context;

    public EpisodeRepository(DoctorWhoCoreDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    public async Task<IEnumerable<Episode>> GetEpisodesAsync(int pageNumber, int pageSize)
    {
        var collection = _context.Episodes as IQueryable<Episode>;

        var collectionToReturn = await collection.OrderBy(e => e.SeriesNumber)
            .ThenBy(e => e.EpisodeNumber)
            .Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

        return collectionToReturn;
    }
}