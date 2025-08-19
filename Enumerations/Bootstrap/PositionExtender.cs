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
}