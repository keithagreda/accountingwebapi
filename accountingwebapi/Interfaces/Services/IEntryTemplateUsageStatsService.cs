namespace accountingwebapi.Interfaces.Services
{
    public interface IEntryTemplateUsageStatsService
    {
        Task AddUsage(Ulid entryTemplateId);
    }
}