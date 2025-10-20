using System.Text;
using Uwn.Razor.Enumerations;

namespace Uwn.Razor.Models;

public sealed class WidthDefinition
{
	public int? MinWidth { get; set; }
	public int? FixedWidth { get; set; }
	public int? MaxWidth { get; set; }

	public LengthUnit LengthUnit { get; set; } = RelativeLengthUnit.RootFontSize;

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
}
