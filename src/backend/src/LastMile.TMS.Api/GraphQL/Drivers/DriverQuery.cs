using HotChocolate;
using HotChocolate.Authorization;
using LastMile.TMS.Application.Drivers.DTOs;
using LastMile.TMS.Application.Drivers.Queries;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Drivers;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class DriverQuery
{
    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<IReadOnlyList<DriverListItemDto>> GetDrivers(
        Guid? depotId = null,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetDriversQuery(depotId), cancellationToken);
}
