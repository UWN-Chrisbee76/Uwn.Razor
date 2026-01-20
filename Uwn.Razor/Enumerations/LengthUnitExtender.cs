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

	public static Dictionary<string, Dictionary<int, string>> GetGroupedValues()
	{
		var absolute = Enum
			.GetValues<AbsoluteLengthUnit>()
			.Cast<AbsoluteLengthUnit>()
			.DistinctBy(e => (int)e)
			.ToDictionary(e => (int)e, e => e.ToString());
		var relative = Enum
			.GetValues<RelativeLengthUnit>()
			.Cast<RelativeLengthUnit>()
			.DistinctBy(e => (int)e)
			.ToDictionary(e => (int)e, e => e.ToString());
		return new Dictionary<string, Dictionary<int, string>>
		{
			{ nameof(AbsoluteLengthUnit), absolute },
			{ nameof(RelativeLengthUnit), relative }
		};
	}

	public static Type? GetLengthUnitType(int value)
		=> value is 0 ? null : value is > 100 and < 200 ? typeof(AbsoluteLengthUnit) : value is > 200 and < 300 ? typeof(RelativeLengthUnit) : throw new ArgumentOutOfRangeException($"'{value}' does not represent a LengthUnit.");
}
