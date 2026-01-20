using Microsoft.AspNetCore.Components;
using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Models.ViewModels.Bootstrap.Modals;

public sealed partial class ModalDialogViewModel
	: ChildContentViewModel
{
	[ObservableProperty] private string? _htmlContent;
	[ObservableProperty] private ModalFullscreenMode _fullscreenMode = ModalFullscreenMode.None;
	[ObservableProperty] private bool _isAnimated = true;
	[ObservableProperty] private bool _isCentered = true;
	[ObservableProperty] private bool _isScrollable = true;
	[ObservableProperty] private ModalSize _size = ModalSize.Default;
	[ObservableProperty] private Content? _title;
	[ObservableProperty] private bool _hasOkCommand = true;
	[ObservableProperty] private EventCallback<string>? _onOkCommand;
	[ObservableProperty] private string? _okCommandParameter;
	[ObservableProperty] private EventCallback? _onDismissed;

	public async Task PrepareAsync()
	{
		IsVisible = true;
		await Task.Yield();
	}

	public override async Task ShowAsync()
		=> await Task.Yield();

	public Task ShowAsync(string title, string htmlContent, EventCallback<string>? onOkCommand, string? okCommandParameter, EventCallback? onDismissed)
	{
		Reset();
		Title = title;
		HtmlContent = htmlContent;
		HasOkCommand = onOkCommand is not null;
		OnOkCommand = onOkCommand;
		OkCommandParameter = okCommandParameter;
		OnDismissed = onDismissed;
		return Task.CompletedTask;
	}
}
