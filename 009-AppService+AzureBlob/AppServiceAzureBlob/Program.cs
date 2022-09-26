using AppServiceAzureBlob.Models;
using AppServiceAzureBlob.Services;
using AppServiceAzureBlob.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Map and register in services the configuration Section of the Settings
builder.Services.Configure<StorageConfiguration>(builder.Configuration.GetSection(nameof(StorageConfiguration)));

// Add services to the container.
builder.Services.AddRazorPages();

// Register the services
builder.Services.AddSingleton<IBlobService, AzureBlobService>();
builder.Services.AddSingleton<IQueueService, AzureQueueService>();
builder.Services.AddSingleton<ITableService, AzureTableService>();

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

app.MapRazorPages();

app.Run();
