using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public partial class ContentViewModel
	: BaseViewModel
{
	[ObservableProperty] private Content? _content;
}
