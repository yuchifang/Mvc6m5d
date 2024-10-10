using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
if (builder.Environment.IsDevelopment())
{
    //
    // 測試 prod azure
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Production.json");
    // var ConnectString = builder.Configuration.GetConnectionString("IronThirty");
    // builder.Services.AddDbContext<BlogDbContext>(Options =>
    // {
    //     Options.UseMySql(ConnectString, ServerVersion.AutoDetect(ConnectString));
    // });
    var ConnectString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
    builder.Services.AddDbContext<BlogDbContext>(Options =>
    {
        Options.UseSqlServer(
            ConnectString,
            providerOptions => providerOptions.EnableRetryOnFailure()
        );
    });
}
else
{
    var ConnectString = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
    builder.Services.AddDbContext<BlogDbContext>(Options =>
    {
        Options.UseSqlServer(ConnectString);
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
