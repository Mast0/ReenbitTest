using ReenbitTest.Components;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var confBuilder = new ConfigurationBuilder();

confBuilder.AddJsonFile("appsettings.json");
var conf = confBuilder.Build();

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddAzureClients(clientBuilder =>
{
	// Register clients
	clientBuilder.AddBlobServiceClient(conf.GetConnectionString("AzureConnectionString"));
});

var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
