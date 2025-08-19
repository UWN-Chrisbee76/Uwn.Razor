namespace Uwn.Razor.Enumerations.Bootstrap;

public static class StyleExtender
{
	public static string GetStyleName(this Style style)
		=> style == Style.None ? string.Empty : style.ToString().ToLower();

	public static string GetAlertClassName(this Style style)
		=> style == Style.None ? string.Empty : $"alert-{GetStyleName(style)}";

	public static string GetBackgroundClassName(this Style style)
		=> style == Style.None ? string.Empty : $"bg-{GetStyleName(style)}";

	public static string GetBorderClassName(this Style style)
		=> style == Style.None ? string.Empty : $"border-{GetStyleName(style)}";

	public static string GetTextClassName(this Style style)
		=> style == Style.None ? string.Empty : $"text-{GetStyleName(style)}";

	public static string GetTextBackgroundClassName(this Style style)
		=> style == Style.None ? string.Empty : $"text-bg-{GetStyleName(style)}";
}