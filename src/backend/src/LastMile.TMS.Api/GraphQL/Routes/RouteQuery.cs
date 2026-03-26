using HotChocolate;
using HotChocolate.Authorization;
using LastMile.TMS.Application.Common;
using LastMile.TMS.Application.Routes.DTOs;
using LastMile.TMS.Application.Routes.Queries;
using LastMile.TMS.Domain.Enums;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Routes;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class RouteQuery
{
    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<PaginatedResult<RouteDto>> GetRoutes(
        Guid? vehicleId = null,
        RouteStatus? status = null,
        int page = 1,
        int pageSize = 20,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetRoutesQuery(vehicleId, status, page, pageSize), cancellationToken);

    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<RouteDto?> GetRoute(
        Guid id,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetRouteByIdQuery(id), cancellationToken);

    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<PaginatedResult<RouteDto>> GetVehicleHistory(
        Guid vehicleId,
        RouteStatus? status = null,
        int page = 1,
        int pageSize = 10,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new GetRoutesQuery(vehicleId, status, page, pageSize), cancellationToken);
}
