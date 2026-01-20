using Uwn.Mvvm;

namespace Uwn.Razor.Models;

public partial class Content
	: ObservableObject
{
	// Properties

	[ObservableProperty] private string? _icon;
	[ObservableProperty] private string? _text;

	// Constructors

	public Content() { }
	public Content(string? text) : this(null, text) { }
	public Content(string? icon, string? text)
	{
		Icon = icon;
		Text = text;
	}

	// Implicit conversion

	public static implicit operator Content(string? text) => new(text);

	// Methods

	public override string ToString()
		=> $"{{ Icon='{Icon}', Text='{Text}' }}".Trim();
}
