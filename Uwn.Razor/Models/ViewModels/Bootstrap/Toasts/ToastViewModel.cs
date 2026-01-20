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
		Content = new(IconNames.StatusSuccess, message);
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
		Content = new(IconNames.StatusInformation, message);
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
		Content = new(IconNames.StatusWarning, message);
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
		Content = new(IconNames.StatusError, message);
		DismissOptions = DismissOptions.Permanent;
		await ShowAsync();
	}

	public async Task ShowExceptionAsync(Exception ex)
		=> await ShowErrorAsync(ex.GetType().Name, ex.Message);
}
