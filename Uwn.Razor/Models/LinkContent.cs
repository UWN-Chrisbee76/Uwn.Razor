using Uwn.Mvvm;

namespace Uwn.Razor.Models;

public sealed partial class LinkContent
	: Content
{
	// Properties

	[ObservableProperty] private Link? _link;

	// Constructors

	public LinkContent() { }
	public LinkContent(string? text) : this(null, text, null) { }
	public LinkContent(string? icon, string? text) : this(icon, text, null) { }
	public LinkContent(string? text, Link? link) : this(null, text, link) { }
	public LinkContent(Content? content) : this(content, null) { }
	public LinkContent(Link? link) : this(null, null, link) { }
	public LinkContent(Content? content, Link? link) : this(content?.Icon, content?.Text, link) { }
	public LinkContent(string? icon, string? text, Link? link)
		: base(icon, text) => Link = link;

	// Implicit conversion

	public static implicit operator LinkContent(string? text) => new(text);
	public static implicit operator LinkContent(Link? link) => new(link);

	// Methods

	public override string ToString()
		=> $"{{ Icon='{Icon}', Text='{Text}', Link='{Link}' }}";
}
