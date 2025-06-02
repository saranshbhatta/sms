using SchoolManagement.Application.AppServices.SchoolAppService;
using SchoolManagement.Web.Host.ApiRegistration;
using SchoolManagement.Web.Host.ServiceCollection;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(option =>
{
    option.Cookie.Name = "SchoolManagement.Session";
    option.Cookie.HttpOnly = true;
    option.Cookie.IsEssential = true;
});


builder.Services.Scan(x =>
    x.FromAssemblies(typeof(SchoolAppService).Assembly)
        .AddClasses(filter => filter.Where(y => y.Name.EndsWith("AppService")),
            publicOnly: false)
        .UsingRegistrationStrategy(RegistrationStrategy.Throw)
        .AsMatchingInterface()
        .WithScopedLifetime()
);

builder.Services.SchoolManagementApplicationCollectionList(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "School Management API v1");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.RegisterAppApis();

app.Run();