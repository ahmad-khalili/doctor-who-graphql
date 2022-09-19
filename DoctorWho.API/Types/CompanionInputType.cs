using DoctorWho.Db.Entities;
using GraphQL.Types;

namespace DoctorWho.API.Types;

public sealed class CompanionInputType : InputObjectGraphType<Companion>
{
    public CompanionInputType()
    {
        Field(c => c.CompanionName);
        Field(c => c.WhoPlayed);
    }
}