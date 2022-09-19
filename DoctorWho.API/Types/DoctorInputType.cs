using DoctorWho.Db.Entities;
using GraphQL;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class DoctorInputType : InputObjectGraphType<Doctor>
{
    public DoctorInputType()
    {
        Field(d => d.DoctorName);
        Field(d => d.DoctorNumber);
        Field(d => d.BirthDate);
        Field(d => d.FirstEpisodeDate);
        Field(d => d.LastEpisodeDate);
    }
}