using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class AppearanceViewModel
	: ContentViewModel
{
	[ObservableProperty] private Appearance _appearance = new();
}
