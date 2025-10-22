using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Components.Bootstrap.Alerts;

public sealed class SuccessAlert
	: Alert
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		Style = Style.Success;
		Position = Position.StickyTop;
		Icon = "fa-circle-check";
		Content = GetTranslation("SuccessMessage");
		Delay = 2000;
		HasCloseButton = false;
	}
}
