using Microsoft.AspNetCore.Components;

namespace Uwn.Razor.Components;

public abstract class UwnComponentWithRouteBase : UwnComponentBase
{
	[Parameter] public string Route { get; set; } = string.Empty;
	[Parameter] public string? IdString { get; set; }

	protected string RouteWithId => $"{Route}/{IdString}";
}
