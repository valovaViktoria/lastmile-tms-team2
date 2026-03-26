using HotChocolate;
using HotChocolate.Authorization;
using LastMile.TMS.Application.Depots.DTOs;
using LastMile.TMS.Application.Depots.Queries;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Depots;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class DepotQuery
{
    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public async Task<IReadOnlyList<DepotDto>> GetDepots(
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetAllDepotsQuery(), cancellationToken);
    }

    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<DepotDto?> GetDepot(
        Guid id,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetDepotByIdQuery(id), cancellationToken);
}
