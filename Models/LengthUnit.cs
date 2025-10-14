using Uwn.Razor.Enumerations;

namespace Uwn.Razor.Models;

public readonly struct LengthUnit
{
	public AbsoluteLengthUnit? Absolute { get; }
	public RelativeLengthUnit? Relative { get; }

	private LengthUnit(AbsoluteLengthUnit unit) => Absolute = unit;
	private LengthUnit(RelativeLengthUnit unit) => Relative = unit;

	public static implicit operator LengthUnit(AbsoluteLengthUnit unit) => new(unit);
	public static implicit operator LengthUnit(RelativeLengthUnit unit) => new(unit);

	public string GetName()
		=> Absolute is not null ? Absolute.Value.GetName() : Relative is not null ? Relative.Value.GetName() : string.Empty;
}
