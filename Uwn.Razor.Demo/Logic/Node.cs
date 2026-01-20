namespace Uwn.Razor.Demo.Logic;

internal sealed class Node(string name)
{
	public string Name { get; } = name;

	public string? Route { get; set; }

	public SortedDictionary<string, Node> Children { get; } = new(StringComparer.OrdinalIgnoreCase);
}