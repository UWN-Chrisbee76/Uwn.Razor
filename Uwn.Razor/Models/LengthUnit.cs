using Uwn.Razor.Enumerations;

namespace Uwn.Razor.Models;

// Not observable, as it is not meant to be modified on the fly
public sealed class LengthUnit
{
	// Properties

	public AbsoluteLengthUnit? Absolute { get; private set; }
	public RelativeLengthUnit? Relative { get; private set; }

	public int RawValue
	{
		get
		{
			if (Absolute.HasValue) return (int)Absolute.Value;
			else if (Relative.HasValue) return (int)Relative.Value;
			else return 0;
		}
		set
		{
			Absolute = null;
			Relative = null;
			if (value != 0)
			{
				var type = LengthUnitExtender.GetLengthUnitType(value);
				if (type == typeof(AbsoluteLengthUnit)) Absolute = (AbsoluteLengthUnit)value;
				else if (type == typeof(RelativeLengthUnit)) Relative = (RelativeLengthUnit)value;
			}
		}
	}

	// Constructors

	public LengthUnit(AbsoluteLengthUnit unit) => Absolute = unit;
	public LengthUnit(RelativeLengthUnit unit) => Relative = unit;
	public LengthUnit(string value)
	{
		if (Enum.TryParse<AbsoluteLengthUnit>(value, out var absolute))
			Absolute = absolute;
		else if (Enum.TryParse<RelativeLengthUnit>(value, out var relative))
			Relative = relative;
	}

	// Implicit conversion

	public static implicit operator LengthUnit(AbsoluteLengthUnit unit) => new(unit);
	public static implicit operator LengthUnit(RelativeLengthUnit unit) => new(unit);
	public static implicit operator LengthUnit(string value) => new(value);

	// Methods

	public string GetName()
		=> Absolute is not null ? Absolute.Value.GetName() : Relative is not null ? Relative.Value.GetName() : string.Empty;

	public override string ToString()
		=> GetName();
}
