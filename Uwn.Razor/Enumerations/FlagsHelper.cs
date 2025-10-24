using System.Numerics;

namespace Uwn.Razor.Enumerations;

public sealed class FlagsHelper
{
	public static bool HasNoFlagsSet<T>(T value) where T : Enum
		=> Convert.ToUInt64(value) == 0;

	public static bool HasAnyFlagsSet<T>(T value) where T : Enum
		=> Convert.ToUInt64(value) != 0;

	public static bool HasMultipleFlagsSet<T>(T value) where T : Enum
		=> CountSetBits(value) > 1;

	public static bool HasNoOrMultipleFlagsSet<T>(T value) where T : Enum
	{
		var count = CountSetBits(value);
		return count == 0 || count > 1;
	}

	public static bool HasExactlyOneFlagSet<T>(T value) where T : Enum
		=> CountSetBits(value) == 1;

	private static int CountSetBits<T>(T value) where T : Enum
		=> BitOperations.PopCount(Convert.ToUInt64(value));
}
