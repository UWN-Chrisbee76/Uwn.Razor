using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels.Bootstrap;

public sealed partial class WaitIndicatorViewModel
	: BaseViewModel
{
	[ObservableProperty] private bool _fullscreen = false;
	[ObservableProperty] private bool _displayTime = true;
	[ObservableProperty] private bool _displayText = true;
	[ObservableProperty] private int _minimumBusyMilliseconds = 500;

	private DateTime? _visibleSince;

	public override async Task ShowAsync()
	{
		_visibleSince = DateTime.UtcNow;
		IsVisible = true;
		await Task.Yield();
	}

	public override async Task HideAsync()
	{
		var span = DateTime.UtcNow - _visibleSince.GetValueOrDefault();
		if (span.TotalMilliseconds < MinimumBusyMilliseconds)
			await Task.Delay(MinimumBusyMilliseconds - (int)span.TotalMilliseconds);
		_visibleSince = null;
		IsVisible = false;
	}
}
