namespace Uwn.Razor.Models;

public struct DismissOptions
{
	public int Delay { get; set; } = 0;
	public bool HasCloseButton { get; set; } = true;

	public DismissOptions() { }
	public DismissOptions(int delay) => Delay = delay;
	public DismissOptions(bool hasCloseButton) => HasCloseButton = hasCloseButton;
	public DismissOptions(int delay, bool hasCloseButton)
	{
		Delay = delay;
		HasCloseButton = hasCloseButton;
	}

	public static DismissOptions Permanent => new(0, false);
	public static DismissOptions Temporary => new(3000, true);
}
