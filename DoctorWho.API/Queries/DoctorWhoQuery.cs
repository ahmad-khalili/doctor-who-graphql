﻿using DoctorWho.API.Types;
using DoctorWho.Db.Repositories;
using GraphQL;
using GraphQL.Types;

namespace DoctorWho.API.Queries;

public sealed class DoctorWhoQuery : ObjectGraphType
{
    public DoctorWhoQuery()
    {
        var defaultQueryArguments = new QueryArguments
        {
            new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", DefaultValue = 1 },
            new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", DefaultValue = 3 }
        };
        
        Field<ListGraphType<DoctorType>>("doctors",
            arguments: new QueryArguments
            {
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageNumber", DefaultValue = 1},
                new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "pageSize", DefaultValue = 3}
            },
            resolve: context =>
            {
                var pageNumber = context.GetArgument<int>("pageNumber");
                var pageSize = context.GetArgument<int>("pageSize");
                var repository = context.RequestServices.GetRequiredService<IDoctorRepository>();
                
                return repository.GetDoctors(pageNumber, pageSize);
            });

        Field<ListGraphType<EpisodeType>>("episodes").Arguments(defaultQueryArguments)
            .ResolveAsync(async context =>
            {
                var repository = context.RequestServices!.GetRequiredService<IEpisodeRepository>();
                var pageNumber = await context.GetValidatedArgumentAsync<int>("pageNumber");
                var pageSize = await context.GetValidatedArgumentAsync<int>("pageSize");

                return await repository.GetEpisodesAsync(pageNumber, pageSize);
            });
    }
}