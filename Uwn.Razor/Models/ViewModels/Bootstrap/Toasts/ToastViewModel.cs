using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;
using Uwn.Razor.Services;

namespace Uwn.Razor.Models.ViewModels.Bootstrap.Toasts;

public sealed partial class ToastViewModel
	: NotificationViewModel
{
	[ObservableProperty] private string _triggerId = string.Empty;

	public async Task ShowSuccessAsync(string message)
		=> await ShowSuccessAsync(null, message);
	public async Task ShowSuccessAsync(string? header, string message)
	{
		Reset();
		Appearance = new Appearance(Style.Success);
		Header = header;
		Icon = IconNames.StatusSuccess;
		Content = message;
		DismissOptions = DismissOptions.Temporary;
		await ShowAsync();
	}

	public async Task ShowInformationAsync(string message)
		=> await ShowInformationAsync(null, message);
	public async Task ShowInformationAsync(string? header, string message)
	{
		Reset();
		Appearance = new Appearance(Style.Info);
		Header = header;
		Icon = IconNames.StatusInformation;
		Content = message;
		DismissOptions = DismissOptions.Temporary;
		await ShowAsync();
	}

	public async Task ShowWarningAsync(string message)
		=> await ShowWarningAsync(null, message);
	public async Task ShowWarningAsync(string? header, string message)
	{
		Reset();
		Appearance = new Appearance(Style.Warning);
		Header = header;
		Icon = IconNames.StatusWarning;
		Content = message;
		DismissOptions = DismissOptions.Permanent;
		await ShowAsync();
	}

	public async Task ShowErrorAsync(string message)
		=> await ShowErrorAsync(null, message);
	public async Task ShowErrorAsync(string? header, string message)
	{
		Reset();
		Appearance = new Appearance(Style.Danger);
		Header = header;
		Icon = IconNames.StatusError;
		Content = message;
		DismissOptions = DismissOptions.Permanent;
		await ShowAsync();
	}

	public async Task ShowExceptionAsync(Exception ex)
		=> await ShowErrorAsync(ex.GetType().Name, ex.Message);
}
