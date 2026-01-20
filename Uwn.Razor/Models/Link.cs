using Uwn.Mvvm;

namespace Uwn.Razor.Models;

public sealed partial class Link
	: Content
{
	// Properties

	[ObservableProperty] private string _href = string.Empty;

	// Constructors

	public Link() : this(null, null, string.Empty) { }
	public Link(string href) : this(null, null, href) { }
	public Link(string? text, string href) : this(null, text, href) { }
	public Link(string? icon, string? text, string href)
		: base(icon, text) => Href = href;

	// Implicit conversion

	public static implicit operator Link(string href) => new(href);

	// Static factory properties

	// Methods

	public override string ToString()
		=> $"{{ Icon='{Icon}', Text='{Text}', Href='{Href}' }}";
}