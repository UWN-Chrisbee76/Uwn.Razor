using System.Text;
using Uwn.Mvvm;
using Uwn.Razor.Enumerations;

namespace Uwn.Razor.Models;

public sealed partial class WidthDefinition
	: ObservableObject
{
	// Properties

	[ObservableProperty] private int? _minWidth;
	[ObservableProperty] private int? _fixedWidth;
	[ObservableProperty] private int? _maxWidth;
	[ObservableProperty] private LengthUnit _lengthUnit = RelativeLengthUnit.RootFontSize;

	// Constructors

	public WidthDefinition() { }
	public WidthDefinition(int? minWidth, int? fixedWidth, int? maxWidth) : this(minWidth, fixedWidth, maxWidth, RelativeLengthUnit.RootFontSize) { }
	public WidthDefinition(LengthUnit lengthUnit) : this(null, null, null, lengthUnit) { }
	public WidthDefinition(int? minWidth, int? fixedWidth, int? maxWidth, LengthUnit lengthUnit)
	{
		MinWidth = minWidth;
		FixedWidth = fixedWidth;
		MaxWidth = maxWidth;
		LengthUnit = lengthUnit;
	}
	public WidthDefinition(string value)
	{
		var span = value.AsSpan();
		var index = span.IndexOf(' ');
		ReadOnlySpan<char> numSpan, textSpan;
		if (index > 0)
		{
			numSpan = span[..index];
			textSpan = span[(index + 1)..];
		}
		else
		{
			index = 0;
			while (index < span.Length && char.IsDigit(span[index])) index++;
			numSpan = span[..index];
			textSpan = span[index..];
		}
		if (int.TryParse(numSpan, out var maxWidth))
		{
			MaxWidth = maxWidth;
			LengthUnit = new LengthUnit(textSpan.ToString());
		}
	}

	// Implicit conversion

	public static implicit operator WidthDefinition(string value) => new(value);

	// Static factory properties

	public static WidthDefinition Min50Percent => new(50, null, null, RelativeLengthUnit.Percent);
	public static WidthDefinition Fixed50Percent => new(null, 50, null, RelativeLengthUnit.Percent);
	public static WidthDefinition Max50Percent => new(null, null, 50, RelativeLengthUnit.Percent);

	public static WidthDefinition Min20Rem => new(20, null, null, RelativeLengthUnit.RootFontSize);
	public static WidthDefinition Fixed20Rem => new(null, 20, null, RelativeLengthUnit.RootFontSize);
	public static WidthDefinition Max20Rem => new(null, null, 20, RelativeLengthUnit.RootFontSize);

	public static WidthDefinition Min40Rem => new(40, null, null, RelativeLengthUnit.RootFontSize);
	public static WidthDefinition Fixed40Rem => new(null, 40, null, RelativeLengthUnit.RootFontSize);
	public static WidthDefinition Max40Rem => new(null, null, 40, RelativeLengthUnit.RootFontSize);

	public static WidthDefinition Min80Rem => new(80, null, null, RelativeLengthUnit.RootFontSize);
	public static WidthDefinition Fixed80Rem => new(null, 80, null, RelativeLengthUnit.RootFontSize);
	public static WidthDefinition Max80Rem => new(null, null, 80, RelativeLengthUnit.RootFontSize);

	// Methods

	public string GetCssStyle()
	{
		var unitName = LengthUnit.GetName();
		var builder = new StringBuilder();
		if (MinWidth is not null)
			builder.Append($"min-width: {MinWidth.Value}{unitName}; ");
		if (FixedWidth is not null)
			builder.Append($"width: {FixedWidth.Value}{unitName}; ");
		if (MaxWidth is not null)
			builder.Append($"max-width: {MaxWidth.Value}{unitName}; ");
		return builder.ToString().Trim();
	}

	public override string ToString()
	{
		var builder = new StringBuilder();
		builder.Append("{ ");
		if (MinWidth is not null) builder.Append($"Min='{MinWidth}', ");
		if (FixedWidth is not null) builder.Append($"Fixed='{FixedWidth}', ");
		if (MaxWidth is not null) builder.Append($"Max='{MaxWidth}', ");
		builder.Append($"LengthUnit='{LengthUnit}'");
		builder.Append(" }");
		return builder.ToString();
	}
}
