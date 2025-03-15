namespace BookSummary.Application.Interfaces
{
    public interface IUserInterface
    {
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(UserDto userDto);
        Task<UserDto> GetUserListAsync();
        Task<UserDto> DeleteUserByIdAsync(int id);
        Task<UserDto> UpdateUserByIdAsync(int id);
    }
}
