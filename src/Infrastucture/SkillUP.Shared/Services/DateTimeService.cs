using SkillUP.Domain.Interfaces;

namespace SkillUP.Shared.Services;

public class DateTimeService : IDateTimeService
{
    public DateTime NowUtc => DateTime.UtcNow;
}
