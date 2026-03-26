using HotChocolate;
using HotChocolate.Authorization;
using LastMile.TMS.Application.Common;
using LastMile.TMS.Application.Vehicles.DTOs;
using LastMile.TMS.Application.Vehicles.Queries;
using LastMile.TMS.Domain.Enums;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Vehicles;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class VehicleQuery
{
    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<PaginatedResult<VehicleDto>> GetVehicles(
        int page = 1,
        int pageSize = 20,
        VehicleStatus? status = null,
        Guid? depotId = null,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetVehiclesQuery(page, pageSize, status, depotId), cancellationToken);

    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<VehicleDto?> GetVehicle(
        Guid id,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetVehicleByIdQuery(id), cancellationToken);
}
