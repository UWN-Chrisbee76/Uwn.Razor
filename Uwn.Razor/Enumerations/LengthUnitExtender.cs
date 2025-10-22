namespace Uwn.Razor.Enumerations;

public static class LengthUnitExtender
{
	public static string GetName(this AbsoluteLengthUnit unit)
		=> unit switch
		{
			AbsoluteLengthUnit.Centimeter => "cm",
			AbsoluteLengthUnit.Inch => "in",
			AbsoluteLengthUnit.Millimeter => "mm",
			AbsoluteLengthUnit.Pica => "pc",
			AbsoluteLengthUnit.Pixel => "px",
			AbsoluteLengthUnit.Point => "pt",
			_ => string.Empty
		};

	public static string GetName(this RelativeLengthUnit unit)
		=> unit switch
		{
			RelativeLengthUnit.ElementFontSize => "em",
			RelativeLengthUnit.RootFontSize => "rem",
			RelativeLengthUnit.ViewportHeight => "vh",
			RelativeLengthUnit.ViewportWidth => "vw",
			RelativeLengthUnit.Percent => "%",
			_ => string.Empty
		};
}
