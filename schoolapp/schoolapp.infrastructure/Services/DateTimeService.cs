using schoolapp.application.Common.Interfaces;

namespace schoolapp.Infrastructure.Services;

public class DateTimeService : IDateTimeService
{
    public static DateTimeOffset Now => DateTime.UtcNow;
}
