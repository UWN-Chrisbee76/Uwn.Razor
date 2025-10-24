using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class DismissOptionsViewModel
	: AppearanceViewModel
{
	[ObservableProperty] DismissOptions _dismissOptions = new(0, true);
}
