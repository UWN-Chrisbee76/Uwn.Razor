using System.Text;
using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Models;

public sealed partial class Appearance
	: ObservableObject
{
	// Properties

	[ObservableProperty] private Style _style = Style.None;
	[ObservableProperty] private Decorations _decorations = Decorations.None;

	// Constructors

	public Appearance() { }
	public Appearance(Style style) => Style = style;
	public Appearance(Decorations decorations) => Decorations = decorations;
	public Appearance(Style style, Decorations decorations)
	{
		Style = style;
		Decorations = decorations;
	}
	public Appearance(string value)
	{
		var parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		foreach (var part in parts)
		{
			if (Enum.TryParse<Style>(part, out var style))
				Style = style;
			else if (Enum.TryParse<Decorations>(part, out var decorations))
				Decorations |= decorations;
		}
	}

	// Implicit conversion

	public static implicit operator Appearance(Style style) => new(style);
	public static implicit operator Appearance(Decorations decorations) => new(decorations);
	public static implicit operator Appearance(string value) => new(value);

	// Static factory properties

	public static Appearance Information => new(Style.Info);
	public static Appearance InformationShadow => new(Style.Info, Decorations.Shadow);
	public static Appearance Success => new(Style.Success);
	public static Appearance SuccessShadow => new(Style.Success, Decorations.Shadow);
	public static Appearance Warning => new(Style.Warning);
	public static Appearance WarningShadow => new(Style.Warning, Decorations.Shadow);
	public static Appearance Error => new(Style.Danger);
	public static Appearance ErrorShadow => new(Style.Danger, Decorations.Shadow);

	// Methods

	public IEnumerable<string> GetClassNames(StyleUsages styleUsages, bool includeDecorations = true)
	{
		var result = new List<string>();
		if (includeDecorations)
			result.AddRange(Decorations.GetClassNames());
		result.AddRange(Style.GetClassNames(styleUsages));
		return result;
	}

	public void AppendClassNames(StyleUsages styleUsages, StringBuilder builder, bool includeDecorations = true)
	{
		foreach (var className in GetClassNames(styleUsages, includeDecorations))
		{
			builder.Append(className);
			builder.Append(' ');
		}
	}

	public override string ToString()
		=> $"{{ Style='{Style}', Decorations='{Decorations}' }}";
}
