using System.Reflection;

namespace Uwn.Razor.Demo.Logic;

internal static class RouteStringsHelper
{
	public static IReadOnlyList<string> GetAllRoutes()
	{
		return [.. typeof(RouteStrings)
			.GetFields(BindingFlags.Public | BindingFlags.Static)
			.Where(f => f.IsLiteral && !f.IsInitOnly && f.FieldType == typeof(string))
			.Select(f => (string)f.GetRawConstantValue()!)
			.Where(s => !string.IsNullOrWhiteSpace(s) && s.StartsWith('/'))
			.Distinct(StringComparer.OrdinalIgnoreCase)
			.OrderBy(s => s, StringComparer.OrdinalIgnoreCase)];
	}
}