using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class ContentViewModel
	: BaseViewModel
{
	[ObservableProperty] private string? _content;
}
