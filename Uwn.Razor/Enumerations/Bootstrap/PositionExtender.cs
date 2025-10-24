using System.Text;

namespace Uwn.Razor.Enumerations.Bootstrap;

public static class PositionExtender
{
	public static string GetClassName(this Position position)
		=> position switch
		{
			Position.FixedBottom => "fixed-bottom",
			Position.FixedTop => "fixed-top",
			Position.StickyBottom => "sticky-bottom",
			Position.StickyTop => "sticky-top",
			_ => string.Empty
		};

	public static string GetAdditionalClassName(this Position position)
		=> position switch
		{
			Position.FixedBottom or Position.FixedTop => "position-fixed",
			Position.StickyBottom or Position.StickyTop => "position-sticky",
			_ => string.Empty,
		};

	public static IEnumerable<string> GetClassNames(this Position position)
	{
		yield return position.GetClassName();
		yield return position.GetAdditionalClassName();
	}

	public static void AppendClassNames(this Position position, StringBuilder builder)
	{
		foreach (var className in position.GetClassNames())
		{
			builder.Append(className);
			builder.Append(' ');
		}
	}
}