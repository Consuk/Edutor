namespace BookSummary.Application.Interfaces
{
    public interface IContentInterface
    {
        Task<ContentDto> GetContentByIdAsync(int id);
        Task<ContentDto> CreateContentAsync(ContentDto ContentDto);
        Task<ContentDto> GetContentListAsync();
        Task<ContentDto> DeleteContentByIdAsync(int id);
        Task<ContentDto> UpdateContentByIdAsync(int id);
    }
}
