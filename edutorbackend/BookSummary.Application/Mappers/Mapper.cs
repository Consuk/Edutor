public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Day, DayDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<Content, ContentDto>().ReverseMap();
        CreateMap<Subject, SubjectDto>().ReverseMap();
    }
}
