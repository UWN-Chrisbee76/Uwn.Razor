using Uwn.Razor.Enumerations.Bootstrap;
using Uwn.Razor.Services;

namespace Uwn.Razor.Components.Bootstrap.Alerts;

public sealed class SuccessAlert
	: Alert
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		Appearance = new Models.Appearance(Style.Success);
		Position = Position.StickyTop;
		Icon = IconNames.StatusSuccess;
		Content = GetTranslation("SuccessMessage");
		DismissOptions = new Models.DismissOptions(3000, false);
	}
}
