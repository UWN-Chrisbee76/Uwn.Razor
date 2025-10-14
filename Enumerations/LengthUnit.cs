namespace Uwn.Razor.Enumerations;

public enum AbsoluteLengthUnit
{
	Centimeter, // cm
	Inch,       // in
	Millimeter, // mm
	Pica,       // pc
	Pixel,      // px
	Point,      // pt

	cm = Centimeter,
	@in = Inch,
	mm = Millimeter,
	pc = Pica,
	px = Pixel,
	pt = Point
}

public enum RelativeLengthUnit
{
	ElementFontSize,    // em
	RootFontSize,       // rem
	ViewportHeight,     // vh
	ViewportWidth,      // vw
	Percent,            // %

	em = ElementFontSize,
	rem = RootFontSize,
	vh = ViewportHeight,
	vw = ViewportWidth
}
