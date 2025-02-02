using Oraora.Builder;
using Oraora.Builder.Seed;
using Oraora.Builder.Services;
using Oraora.InternalMigration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var sqliteConnectionString = configuration.GetConnectionString("Sqlite");

// Add services to the container.
builder.Services.AddServiceCollection();
builder.Services.AddConfigurationProvider(configuration);
builder.Services.AddFluentMigratorProvider(sqliteConnectionString!);
builder.Services.AddMvc();
builder.Services.AddServerSideBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapDefaultControllerRoute();

app.UseEndpoints(endpoint =>
{
    endpoint.MapRazorPages();
    endpoint.MapBlazorHub();
});

app.UseFluentMigrator();
await app.AddProducts();

app.Run();
