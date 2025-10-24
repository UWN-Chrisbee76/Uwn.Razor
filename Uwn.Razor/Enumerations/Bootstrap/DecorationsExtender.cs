using System.Text;

namespace Uwn.Razor.Enumerations.Bootstrap;

public static class DecorationsExtender
{
	public static string GetClassName(this Decorations decoration)
		=> decoration switch
		{
			Decorations.Rounded => "rounded",
			Decorations.Shadow => "shadow",
			_ => string.Empty
		};

	public static IEnumerable<string> GetClassNames(this Decorations decorations)
	{
		foreach (var value in Enum.GetValues<Decorations>())
		{
			if (decorations.HasFlag(value) &&
				FlagsHelper.HasExactlyOneFlagSet(value))
				yield return value.GetClassName();
		}
	}

	public static void AppendClassNames(this Decorations decorations, StringBuilder builder)
	{
		foreach (var className in decorations.GetClassNames())
		{
			builder.Append(className);
			builder.Append(' ');
		}
	}
}
