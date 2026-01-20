using Uwn.Razor.Enumerations.Bootstrap;
using Uwn.Razor.Models;
using Uwn.Razor.Services;

namespace Uwn.Razor.Components.Bootstrap.Toasts;

public sealed class SuccessToast
	: Toast
{
	protected override async Task OnInitializedAsync()
	{
		await base.OnInitializedAsync();
		Position = Position.FixedBottom;
		Header = new Content(IconNames.StatusSuccess, GetTranslation("SuccessHeader"));
		Appearance = new(Style.Success, Decorations.Shadow);
		DismissOptions = DismissOptions.Temporary;
	}
}