using COMACON.ComaconHelper;
using COMACON.config;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Serilog Configuration options
var configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", true)
        .Build();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(configuration).CreateLogger();

builder.Host.UseSerilog();

ComaconHelperProxyOptions proxyOptions = new()
{
    ExecutableFilePath = @"OtherDependencies\COMACON Helper.exe",
    webApplicationDataStructures = new DefaultWebApplicationDataStructures(),
};

builder.Services.AddSingleton(proxyOptions);
builder.Services.AddTransient<ComaconHelperProxy, DefaultComaconHelperProxy>();
builder.Services.AddTransient<GenericHelperMethods, DefaultGenericHelperMethods>();
builder.Services.AddTransient<WebApplicationDataStructures, DefaultWebApplicationDataStructures>();
builder.Services.AddTransient<SessionManagement, DefaultSessionManagement>();
builder.Services.AddTransient<SqlQueries, DefaultSqlQueries>();

builder.Services.AddTransient<Core, DefaultCore>();
builder.Services.AddTransient<LoadSaveWebApplications, DefaultLoadSaveWebApplications>();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Core}/{action=Login}");

app.MapControllers();

app.Run();
