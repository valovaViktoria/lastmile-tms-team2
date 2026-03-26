using HotChocolate;
using HotChocolate.Authorization;
using LastMile.TMS.Application.Routes.Commands;
using LastMile.TMS.Application.Routes.DTOs;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Routes;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class RouteMutation
{
    [Authorize(Roles = new[] { "OperationsManager", "Admin", "Dispatcher" })]
    public Task<RouteDto> CreateRoute(
        CreateRouteDto input,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new CreateRouteCommand(input), cancellationToken);
}
