namespace Uwn.Razor.Enumerations.Bootstrap;

[Flags]
public enum Decorations
{
	None = 0,           // 0

	Rounded = 1 << 0,   // 1
	Shadow = 1 << 1,    // 2

	All = Rounded | Shadow
}
