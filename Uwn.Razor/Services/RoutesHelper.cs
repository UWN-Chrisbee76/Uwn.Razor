using System.Reflection;
using Microsoft.AspNetCore.Components;

namespace Uwn.Razor.Services;

public static class RoutesHelper
{
	private static readonly Dictionary<Type, string[]> _routesByComponent; // Key=Component Type, Value=Routes

	static RoutesHelper()
	{
		var assembly = Assembly.GetEntryAssembly();
		assembly ??= Assembly.GetExecutingAssembly();
		_routesByComponent = assembly
			.ExportedTypes
			.Where(t => typeof(IComponent).IsAssignableFrom(t))
			.Select(t => new
			{
				Type = t,
				Routes = t.GetCustomAttributes<RouteAttribute>().Select(a => a.Template).ToArray()
			})
			.Where(tr => tr.Routes.Length > 0)
			.ToDictionary(tr => tr.Type, tr => tr.Routes);
	}

	public static string[] GetRoutesFor<TComponent>() where TComponent : IComponent
		=> _routesByComponent.TryGetValue(typeof(TComponent), out var routes) ? routes : [];

	public static string GetFirstRouteFor<TComponent>() where TComponent : IComponent
		=> GetRoutesFor<TComponent>().First();
}