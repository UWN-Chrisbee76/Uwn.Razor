using Uwn.Razor.Demo.Components.Shared;
using Uwn.Razor.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services
	.AddRazorComponents()
	.AddInteractiveServerComponents()
	.AddHubOptions(options =>
	{
		options.EnableDetailedErrors = true;
		options.MaximumReceiveMessageSize = 64 * 1024; // 64 KiB
	});
builder.Services.AddCookiePolicy(options =>
{
	options.MinimumSameSitePolicy = SameSiteMode.Lax;
	options.Secure = CookieSecurePolicy.Always;
});
builder.Services.AddApplicationInsightsTelemetry(options =>
{
	options.ConnectionString = builder.Configuration["ApplicationInsights"];
});
builder.Services.AddLocalization();
builder.Services.AddSingleton<UwnCapabilitiesService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}
app.UseStaticFiles();
app.UseRouting();
app.UseCookiePolicy();
app.UseHttpsRedirection();
app.UseAntiforgery();
app
	.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();
app.Run();
