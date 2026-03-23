using HotChocolate.Data;
using HotChocolate.Types.Relay;
using LastMile.TMS.Application.Common.Interfaces;
using LastMile.TMS.Application.Depots.DTOs;
using LastMile.TMS.Application.Depots.Queries;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Queries;

public class DepotQuery
{
    [UsePaging(MaxPageSize = 100)]
    [UseFiltering]
    [UseSorting]
    public async Task<List<DepotDto>> GetDepots([Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetAllDepotsQuery(), cancellationToken);
    }

    public async Task<DepotDto?> GetDepot(Guid id, [Service] IMediator mediator, CancellationToken cancellationToken)
    {
        return await mediator.Send(new Application.Depots.Queries.GetDepotByIdQuery(id), cancellationToken);
    }
}
