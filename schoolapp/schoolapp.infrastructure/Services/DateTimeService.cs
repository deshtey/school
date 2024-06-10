using schoolapp.application.Common.Interfaces;

namespace schoolapp.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public static DateTimeOffset Now => DateTime.Now;
}
