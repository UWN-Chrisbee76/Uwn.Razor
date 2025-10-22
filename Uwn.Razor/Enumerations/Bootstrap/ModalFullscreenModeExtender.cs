namespace Uwn.Razor.Enumerations.Bootstrap;

public static class ModalFullscreenModeExtender
{
	public static string GetClassName(this ModalFullscreenMode mode)
		=> mode switch
		{
			ModalFullscreenMode.None => string.Empty,
			ModalFullscreenMode.Always => "modal-fullscreen",
			ModalFullscreenMode.BelowSmall => "modal-fullscreen-sm-down",
			ModalFullscreenMode.BelowMedium => "modal-fullscreen-md-down",
			ModalFullscreenMode.BelowLarge => "modal-fullscreen-lg-down",
			ModalFullscreenMode.BelowExtraLarge => "modal-fullscreen-xl-down",
			ModalFullscreenMode.BelowExtraExtraLarge => "modal-fullscreen-xxl-down",
			_ => string.Empty
		};
}