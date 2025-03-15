namespace BookSummary.Application;

public void ConfigureServices(IServiceCollection services)
{
    services.AddScoped<IDayService, DayService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IContentService, ContentService>();
    services.AddScoped<ISubjectService, SubjectService>();
    services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    services.AddAutoMapper(typeof(AutoMapperConfig));
}
