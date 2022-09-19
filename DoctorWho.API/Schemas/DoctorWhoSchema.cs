using DoctorWho.API.Queries;
using GraphQL.Types;

namespace DoctorWho.API.Schemas;

public class DoctorWhoSchema : Schema
{
    public DoctorWhoSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<DoctorWhoQuery>();
    }
}