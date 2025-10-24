namespace Uwn.Razor.Enumerations.Bootstrap;

[Flags]
public enum StyleUsages
{
	None = 0,

	Alert = 1 << 0,         //  1
	Background = 1 << 1,    //  2
	Border = 1 << 2,        //  4
	Text = 1 << 3,          //  8
	TextBackground = 1 << 4 // 16
}
