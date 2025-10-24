using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Models.ViewModels.Bootstrap;

public sealed partial class TooltipViewModel
	: ChildContentViewModel
{
	[ObservableProperty] private Placement _placement = Placement.Bottom;
	[ObservableProperty] private string? _content;
	[ObservableProperty] private bool _contentIsHtml = false;

	public async Task ShowAsync(string content, bool contentIsHtml = false)
	{
		Reset();
		Content = content;
		ContentIsHtml = contentIsHtml;
		await ShowAsync();
	}
}
