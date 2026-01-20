using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class NotificationViewModel
	: DismissOptionsViewModel
{
	[ObservableProperty] private Position _position = Position.None;
	[ObservableProperty] private Content? _header;
}
