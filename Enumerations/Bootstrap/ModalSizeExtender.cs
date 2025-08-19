namespace Uwn.Razor.Enumerations.Bootstrap;

public static class ModalSizeExtender
{
	public static string GetClassName(this ModalSize size)
		=> size switch
		{
			ModalSize.Small => "modal-sm",
			ModalSize.Medium => string.Empty,
			ModalSize.Large => "modal-lg",
			ModalSize.ExtraLarge => "modal-xl",
			_ => string.Empty
		};
}