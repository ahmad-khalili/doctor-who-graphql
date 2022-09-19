using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class EpisodeInputType : InputObjectGraphType<Episode>
{
    public EpisodeInputType()
    {
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