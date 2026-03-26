using HotChocolate;
using LastMile.TMS.Application.Zones.DTOs;
using LastMile.TMS.Application.Zones.Queries;
using MediatR;

namespace LastMile.TMS.Api.GraphQL.Zones;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class ZoneQuery
{
    public async Task<List<ZoneDto>> GetZones(
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetAllZonesQuery(), cancellationToken);
    }

    public async Task<ZoneDto?> GetZone(
        Guid id,
        [Service] ISender mediator = null!,
        CancellationToken cancellationToken = default)
    {
        return await mediator.Send(new GetZoneByIdQuery(id), cancellationToken);
    }
}
