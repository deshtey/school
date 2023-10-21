using schoolapp.Application.Common.Interfaces;

namespace schoolapp.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
