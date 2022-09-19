using DoctorWho.API.Mutations;
using DoctorWho.API.Queries;
using GraphQL.Types;

namespace DoctorWho.API.Schemas;

public class DoctorWhoSchema : Schema
{
    public DoctorWhoSchema(IServiceProvider provider) : base(provider)
    {
        Query = provider.GetRequiredService<DoctorWhoQuery>();
        Mutation = provider.GetRequiredService<DoctorWhoMutation>();
    }
}