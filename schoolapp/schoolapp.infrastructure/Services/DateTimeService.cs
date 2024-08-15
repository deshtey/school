using schoolapp.application.Common.Interfaces;

namespace schoolapp.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public DateTimeOffset Now => DateTime.UtcNow;
}
