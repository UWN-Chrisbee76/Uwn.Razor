using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;
using Uwn.Razor.Services;

namespace Uwn.Razor.Models.ViewModels.Bootstrap.Cards;

public sealed partial class CardViewModel
	: AppearanceViewModel
{
	[ObservableProperty] private string? _headerIcon;
	[ObservableProperty] private string? _header;
	[ObservableProperty] private string? _titleIcon;
	[ObservableProperty] private string? _title;
	[ObservableProperty] private string? _subTitle;
	[ObservableProperty] private Link? _bodyLink;
	[ObservableProperty] private string? _footerText;
	[ObservableProperty] private Link? _footerLink;
	[ObservableProperty] private WidthDefinition? _width;

	public async Task ShowExceptionAsync(Exception ex)
	{
		Reset();
		Appearance = new Appearance(Style.Danger);
		Header = ex.GetType().Name;
		TitleIcon = IconNames.StatusError;
		Title = GetTranslation("ExceptionTitle");
		Content = IsDevelopmentEnvironment ? ex.ToString() : ex.Message;
		await ShowAsync();
	}
}
