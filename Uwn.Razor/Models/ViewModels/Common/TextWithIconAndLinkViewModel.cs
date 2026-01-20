using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels.Common;

public sealed partial class TextWithIconAndLinkViewModel
	: ContentViewModel
{
	[ObservableProperty] private Link _link = new(string.Empty);
}
