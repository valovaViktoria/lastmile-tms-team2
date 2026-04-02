using LastMile.TMS.Application.Common.Interfaces;

namespace LastMile.TMS.Infrastructure.Services;

/// <summary>
/// Hangfire entry point for scheduled cleanup of driver photo files not referenced in the database.
/// </summary>
public sealed class DriverPhotoOrphanCleanupJob(IDriverPhotoFileCleanup driverPhotoFileCleanup)
{
    public Task ExecuteAsync(CancellationToken cancellationToken = default) =>
        driverPhotoFileCleanup.DeleteOrphanDriverPhotosAsync(cancellationToken);
}
