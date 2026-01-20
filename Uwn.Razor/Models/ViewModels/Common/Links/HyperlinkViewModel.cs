using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels.Common.Links;

public sealed partial class HyperlinkViewModel
	: BaseViewModel
{
	[ObservableProperty] private Link? _link;
}
