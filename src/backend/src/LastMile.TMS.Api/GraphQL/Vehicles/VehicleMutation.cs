using HotChocolate;
using HotChocolate.Authorization;
using LastMile.TMS.Application.Vehicles.Commands;
using LastMile.TMS.Application.Vehicles.DTOs;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Vehicles;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class VehicleMutation
{
    [Authorize(Roles = new[] { "OperationsManager", "Admin" })]
    public Task<VehicleDto> CreateVehicle(
        CreateVehicleDto input,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new CreateVehicleCommand(input), cancellationToken);

    [Authorize(Roles = new[] { "OperationsManager", "Admin" })]
    public Task<VehicleDto?> UpdateVehicle(
        Guid id,
        UpdateVehicleDto input,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new UpdateVehicleCommand(id, input), cancellationToken);

    [Authorize(Roles = new[] { "OperationsManager", "Admin" })]
    public Task<bool> DeleteVehicle(
        Guid id,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default) =>
        mediator.Send(new DeleteVehicleCommand(id), cancellationToken);
}
