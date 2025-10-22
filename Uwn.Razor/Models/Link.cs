namespace Uwn.Razor.Models;

public sealed record Link(
	string Href,
	string Text,
	string? Icon = null
	);