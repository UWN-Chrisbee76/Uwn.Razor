using System.Text;
using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Models;

public struct Appearance
{
	public Style Style { get; set; } = Style.None;
	public Decorations Decorations { get; set; } = Decorations.None;

	public Appearance() { }
	public Appearance(Style style) => Style = style;
	public Appearance(Decorations decorations) => Decorations = decorations;
	public Appearance(Style style, Decorations decorations)
	{
		Style = style;
		Decorations = decorations;
	}

	public readonly IEnumerable<string> GetClassNames(StyleUsages styleUsages, bool includeDecorations = true)
	{
		var result = new List<string>();
		if (includeDecorations)
			result.AddRange(Decorations.GetClassNames());
		result.AddRange(Style.GetClassNames(styleUsages));
		return result;
	}

	public readonly void AppendClassNames(StyleUsages styleUsages, StringBuilder builder, bool includeDecorations = true)
	{
		foreach (var className in GetClassNames(styleUsages, includeDecorations))
		{
			builder.Append(className);
			builder.Append(' ');
		}
	}
}
