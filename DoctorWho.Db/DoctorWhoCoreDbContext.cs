using DoctorWho.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace DoctorWho.Db;

public class DoctorWhoCoreDbContext : DbContext
{
    public DoctorWhoCoreDbContext(DbContextOptions<DoctorWhoCoreDbContext> options) : base(options) {}

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Enemy> Enemies { get; set; } = null!;
    public DbSet<Companion> Companions { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Episode> Episodes { get; set; } = null!;
    public DbSet<EpisodeEnemy> EpisodeEnemies { get; set; } = null!;
    public DbSet<EpisodeCompanion> EpisodeCompanions { get; set; } = null!;

    public string GetCompanions(int episodeId) => throw new NotSupportedException();
    public string GetEnemies(int episodeId) => throw new NotSupportedException();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enemy>().HasData(
            new Enemy { EnemyId = 1, EnemyName = "The Master",
                Description = "An old friend, and an old foe, The Master has faced the Doctor throughout several lifecycles"},
            new Enemy { EnemyId = 2, EnemyName = "The Daleks",
                Description = "Daleks are a perennial threat to our dual-hearted hero, and are the only villain so far to have faced every version of the Doctor"},
            new Enemy { EnemyId = 3, EnemyName = "The Cybermen",
                Description = "First introduced way back in 1966, they were a part of the First Doctor William Hartnell''s final serial"},
            new Enemy { EnemyId = 4, EnemyName = "The Weeping Angels",
                Description = "These menacing looking statue-like humanoids can kill people with a single touch and can only move when they''re not being looked at, including when people blink"},
            new Enemy { EnemyId = 5, EnemyName = "Sontarans",
                Description = "Round, brown, and great with butter, the Sontarans aren’t to be messed with"}
        );

        modelBuilder.Entity<Companion>().HasData(
            new Companion { CompanionId = 1, CompanionName = "Susan Foreman", WhoPlayed = "Carole Ann Ford"},
            new Companion { CompanionId = 2, CompanionName = "Barbara Wright", WhoPlayed = "Jacqueline Hill"},
            new Companion { CompanionId = 3, CompanionName = "Ian Chesterton", WhoPlayed = "William Russell"},
            new Companion { CompanionId = 4, CompanionName = "Vicki", WhoPlayed = "Maureen O'Brien"},
            new Companion { CompanionId = 5, CompanionName = "Steven Taylor", WhoPlayed = "Peter Purves"}
        );

        modelBuilder.Entity<Author>().HasData(
            new Author { AuthorId = 1, AuthorName = "Ben Aaronovitch"},
            new Author { AuthorId = 2, AuthorName = "Douglas Adams"},
            new Author { AuthorId = 3, AuthorName = "David Agnew"},
            new Author { AuthorId = 4, AuthorName = "Maxine Alderton"},
            new Author { AuthorId = 5, AuthorName = "Bob Baker"}
            );

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor { DoctorId = 1, DoctorName = "William Hartnell", DoctorNumber = 1,
                BirthDate = new DateTime(1908,1,8),
                FirstEpisodeDate = new DateTime(1963,11,23),
                LastEpisodeDate = new DateTime(1966,7,16)},
            new Doctor { DoctorId = 2, DoctorName = "Patrick Troughton", DoctorNumber = 2,
                BirthDate = new DateTime(1920,3,25),
                FirstEpisodeDate = new DateTime(1966,9,10),
                LastEpisodeDate = new DateTime(1968,6,1)},
            new Doctor { DoctorId = 3, DoctorName = "Jon Pertwee", DoctorNumber = 3,
                BirthDate = new DateTime(1919,7,7),
                FirstEpisodeDate = new DateTime(1968,8,10),
                LastEpisodeDate = new DateTime(1972,6,24)},
            new Doctor { DoctorId = 4, DoctorName = "Tom Baker", DoctorNumber = 4,
                BirthDate = new DateTime(1934,1,20),
                FirstEpisodeDate = new DateTime(1976,9,4),
                LastEpisodeDate = new DateTime(1981,3,21)},
            new Doctor { DoctorId = 5, DoctorName = "Peter Davison", DoctorNumber = 5,
                BirthDate = new DateTime(1951,4,15),
                FirstEpisodeDate = new DateTime(1982,1,4),
                LastEpisodeDate = new DateTime(1984,3,30)}
        );

        modelBuilder.Entity<Episode>().HasData(
            new Episode { EpisodeId = 1, SeriesNumber = 1, EpisodeNumber = 14, EpisodeType = "Musical", 
                Title = "The Christmas Invasion", EpisodeDate = new DateTime(2005,12,25), AuthorId = 3, 
                DoctorId = 5, Notes = "Happy Christmas!"},
            new Episode { EpisodeId = 2, SeriesNumber = 1, EpisodeNumber = 15, EpisodeType = "Historical", 
                Title = "The Unquiet Dead", EpisodeDate = new DateTime(2005,4,9), AuthorId = 2, 
                DoctorId = 1, Notes = "History party"},
            new Episode { EpisodeId = 3, SeriesNumber = 2, EpisodeNumber = 7, EpisodeType = "Adventure", 
                Title = "New Earth", EpisodeDate = new DateTime(2006,4,15), AuthorId = 4, 
                DoctorId = 2, Notes = "Earth looks cool"},
            new Episode { EpisodeId = 4, SeriesNumber = 2, EpisodeNumber = 3, EpisodeType = "Horror", 
                Title = "Cold Blood", EpisodeDate = new DateTime(2005,10,19), AuthorId = 1, 
                DoctorId = 3, Notes = "Scary episode"},
            new Episode { EpisodeId = 5, SeriesNumber = 3, EpisodeNumber = 1, EpisodeType = "Action", 
                Title = "Time Crash", EpisodeDate = new DateTime(2007,11,16), AuthorId = 5, 
                DoctorId = 4, Notes = "Nice CGI"}
        );

        modelBuilder.Entity<EpisodeCompanion>().HasData(
            new EpisodeCompanion { EpisodeCompanionId = 1, EpisodeId = 1, CompanionId = 4},
            new EpisodeCompanion { EpisodeCompanionId = 2, EpisodeId = 2, CompanionId = 3},
            new EpisodeCompanion { EpisodeCompanionId = 3, EpisodeId = 3, CompanionId = 2},
            new EpisodeCompanion { EpisodeCompanionId = 4, EpisodeId = 4, CompanionId = 1},
            new EpisodeCompanion { EpisodeCompanionId = 5, EpisodeId = 5, CompanionId = 5}
        );
        
        modelBuilder.Entity<EpisodeEnemy>().HasData(
            new EpisodeEnemy { EpisodeEnemyId = 1, EpisodeId = 1, EnemyId = 4},
            new EpisodeEnemy { EpisodeEnemyId = 2, EpisodeId = 2, EnemyId = 3},
            new EpisodeEnemy { EpisodeEnemyId = 3, EpisodeId = 3, EnemyId = 2},
            new EpisodeEnemy { EpisodeEnemyId = 4, EpisodeId = 4, EnemyId = 1},
            new EpisodeEnemy { EpisodeEnemyId = 5, EpisodeId = 5, EnemyId = 5}
        );

        modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                .GetMethod(nameof(GetCompanions), new[] { typeof(int) })!)
            .HasName("fnCompanions");
        
        modelBuilder.HasDbFunction(typeof(DoctorWhoCoreDbContext)
                .GetMethod(nameof(GetEnemies), new[] { typeof(int) })!)
            .HasName("fnEnemies");
    }
}