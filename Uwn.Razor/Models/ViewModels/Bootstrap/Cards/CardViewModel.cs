using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;
using Uwn.Razor.Services;

namespace Uwn.Razor.Models.ViewModels.Bootstrap.Cards;

public sealed partial class CardViewModel
	: AppearanceViewModel
{
	[ObservableProperty] private Content? _header;
	[ObservableProperty] private Content? _title;
	[ObservableProperty] private Content? _subTitle;
	[ObservableProperty] private Link? _bodyLink;
	[ObservableProperty] private LinkContent? _footer;
	[ObservableProperty] private WidthDefinition? _width;

	public LinkContent? Body => new(Content, BodyLink);

	public async Task ShowExceptionAsync(Exception ex)
	{
		Reset();
		Appearance = new Appearance(Style.Danger);
		Header = ex.GetType().Name;
		Title = new(IconNames.StatusError, GetTranslation("ExceptionTitle"));
		Content = IsDevelopmentEnvironment ? ex.ToString() : ex.Message;
		await ShowAsync();
	}
}
