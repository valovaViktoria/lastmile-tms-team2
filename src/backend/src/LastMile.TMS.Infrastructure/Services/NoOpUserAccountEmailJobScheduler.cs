using LastMile.TMS.Application.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace LastMile.TMS.Infrastructure.Services;

public sealed class NoOpUserAccountEmailJobScheduler(
    ILogger<NoOpUserAccountEmailJobScheduler> logger) : IUserAccountEmailJobScheduler
{
    public Task SchedulePasswordSetupEmailAsync(Guid userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Skipping password setup email scheduling for user {UserId}.", userId);
        return Task.CompletedTask;
    }

    public Task SchedulePasswordResetEmailAsync(Guid userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        logger.LogInformation("Skipping password reset email scheduling for user {UserId}.", userId);
        return Task.CompletedTask;
    }
}
