using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class CompanionType : ObjectGraphType<Companion>
{
    public CompanionType()
    {
        Field(c => c.CompanionId);
        Field(c => c.CompanionName);
        Field(c => c.WhoPlayed);
    }
}