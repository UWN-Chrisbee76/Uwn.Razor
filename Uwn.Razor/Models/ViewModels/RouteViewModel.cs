using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class RouteViewModel
	: ContentViewModel
{
	[ObservableProperty] private string _route = string.Empty;
	[ObservableProperty] private string? _idString;

	public string RouteWithId => $"{Route}/{IdString}";

	public async Task ShowAsync(string route, string? idString = null)
	{
		Reset();
		Route = route;
		IdString = idString;
		await ShowAsync();
	}
}
