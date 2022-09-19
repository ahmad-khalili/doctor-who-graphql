using DoctorWho.API.Types;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using GraphQL;
using GraphQL.Execution;
using GraphQL.Types;

namespace DoctorWho.API.Queries;

public sealed class DoctorQuery : ObjectGraphType
{
    public DoctorQuery()
    {
        Field<ListGraphType<DoctorType>>("doctors",
            arguments: new QueryArguments
            {
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber" },
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize" }
            },
            resolve: context =>
            {
                var pageNumber = context.GetArgument<int>("pageNumber");
                var pageSize = context.GetArgument<int>("pageSize");
                var repository = context.RequestServices.GetRequiredService<IDoctorRepository>();
                
                return repository.GetDoctors(pageNumber, pageSize);
            });
    }
}