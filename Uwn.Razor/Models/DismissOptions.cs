using Uwn.Mvvm;

namespace Uwn.Razor.Models;

public sealed partial class DismissOptions
	: ObservableObject
{
	// Properties

	[ObservableProperty] private int _delay = 0;
	[ObservableProperty] private bool _hasCloseButton = false;

	// Constructors

	public DismissOptions() { }
	public DismissOptions(int delay) => Delay = delay;
	public DismissOptions(bool hasCloseButton) => HasCloseButton = hasCloseButton;
	public DismissOptions(int delay, bool hasCloseButton)
	{
		Delay = delay;
		HasCloseButton = hasCloseButton;
	}
	public DismissOptions(string value)
	{
		var parts = value.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		foreach (var part in parts)
		{
			if (int.TryParse(part, out var delay))
				Delay = delay;
			else if (bool.TryParse(part, out var hasCloseButton))
				HasCloseButton = hasCloseButton;
		}
	}

	// Implicit conversion

	public static implicit operator DismissOptions(int delay) => new(delay);
	public static implicit operator DismissOptions(bool hasCloseButton) => new(hasCloseButton);
	public static implicit operator DismissOptions(string value) => new(value);

	// Static factory properties

	public static DismissOptions Permanent => new(0, false);
	public static DismissOptions Temporary => new(3000, true);

	// Methods

	public override string ToString()
		=> $"{{ Delay={Delay}, HasCloseButton={HasCloseButton} }}";
}
