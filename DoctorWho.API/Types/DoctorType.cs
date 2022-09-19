using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class DoctorType : ObjectGraphType<Doctor>
{
    public DoctorType()
    {
        Name = "Doctor";
        Description = "Doctor Type";
        Field(d => d.DoctorId);
        Field(d => d.DoctorName);
        Field(d => d.DoctorNumber);
        Field(d => d.BirthDate);
        Field(d => d.FirstEpisodeDate);
        Field(d => d.LastEpisodeDate);
    }
}