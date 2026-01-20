using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels.Common.Links;

public sealed partial class ExternalLinkViewModel
	: ChildContentViewModel
{
	[ObservableProperty] private string _href = string.Empty;
}
