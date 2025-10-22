using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Components.Bootstrap.Toasts;

public sealed class SuccessToast
	: Toast
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		Style = Style.Success;
		Position = Position.FixedBottom;
		Icon = "fa-circle-check";
		Header = GetTranslation("SuccessHeader");
		Delay = 2000;
		DropShadow = true;
		HasCloseButton = false;
	}
}