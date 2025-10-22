namespace Uwn.Razor.Enumerations.FontAwesome;

public static class FontAwesomeHelper
{
	public const IconPacks DefaultIconPack = IconPacks.Classic;
	public const Styles DefaultStyle = Styles.Solid;

	public const string SolidClassName = "fa-solid";
	public const string RegularClassName = "fa-regular";
	public const string LightClassName = "fa-light";
	public const string ThinClassName = "fa-thin";

	public const string ClassicClassName = "";
	public const string DuotoneClassName = "fa-duotone";
	public const string SharpClassName = "fa-sharp";
	public const string SharpDuotoneClassName = "fa-sharp-duotone";

	public static int DefaultFlags => ToInt32(DefaultIconPack, DefaultStyle);

	public static void FromInt32(int flags, out IconPacks iconPack, out Styles style)
	{
		iconPack = GetFlag<IconPacks>(flags);
		style = GetFlag<Styles>(flags);
	}

	public static int ToInt32(IconPacks pack, Styles style)
		=> (int)pack | (int)style;

	public static IconPacks GetIconPack(int flags)
	{
		FromInt32(flags, out var iconPack, out _);
		return iconPack;
	}

	public static Styles GetStyle(int flags)
	{
		FromInt32(flags, out _, out var style);
		return style;
	}

	public static TEnum GetFlag<TEnum>(int flags) where TEnum : Enum
	{
		foreach (var enumValue in Enum.GetValues(typeof(TEnum)))
		{
			var intValue = (int)enumValue;
			if (intValue == 0) continue;
			if ((flags & intValue) == intValue)
				return (TEnum)enumValue;
		}
		return default!;
	}

	public static string GetClassName(IconPacks iconPack) => iconPack switch
	{
		IconPacks.Classic => ClassicClassName,
		IconPacks.Duotone => DuotoneClassName,
		IconPacks.Sharp => SharpClassName,
		IconPacks.SharpDuotone => SharpDuotoneClassName,
		_ => string.Empty
	};

	public static string GetClassName(Styles style) => style switch
	{
		Styles.Solid => SolidClassName,
		Styles.Regular => RegularClassName,
		Styles.Light => LightClassName,
		Styles.Thin => ThinClassName,
		_ => string.Empty,
	};

	public static string GetClassNames(int flags)
	{
		FromInt32(flags, out var iconPack, out var style);
		return $"{GetClassName(iconPack)} {GetClassName(style)}".Trim();
	}
}
