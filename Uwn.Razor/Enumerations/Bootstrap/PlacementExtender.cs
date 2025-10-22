namespace Uwn.Razor.Enumerations.Bootstrap;

public static class PlacementExtender
{
	public static string ToBootstrapName(this Placement placement)
		=> placement.ToString().ToLower();
}
