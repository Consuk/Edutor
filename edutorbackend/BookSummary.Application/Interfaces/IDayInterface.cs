namespace BookSummary.Application.Interfaces
{
    public interface IDayInterface
    {
        Task<DayDto> GetDayByIdAsync(int id);
        Task<DayDto> CreateDayAsync(DayDto DayDto);
        Task<DayDto> GetDayListAsync();
        Task<DayDto> DeleteDayByIdAsync(int id);
        Task<DayDto> UpdateDayByIdAsync(int id);
    }
}
