using DoctorWho.Db.Entities;
using DoctorWho.Db.Repositories;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public class EpisodeType : ObjectGraphType<Episode>
{
    public EpisodeType()
    {
        Field(e => e.EpisodeId);
        Field(e => e.SeriesNumber);
        Field(e => e.EpisodeNumber);
        Field(e => e.Title);
        Field(e => e.EpisodeType);
        Field(e => e.EpisodeDate);
        Field(e => e.AuthorId);
        Field(e => e.DoctorId);
        Field(e => e.Notes);
    }
}