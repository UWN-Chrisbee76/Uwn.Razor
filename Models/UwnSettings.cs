using Uwn.Razor.Enumerations.FontAwesome;

namespace Uwn.Razor.Models;

public sealed class UwnSettings
{
	public IconPacks FontAwesomeIconPack { get; set; } = FontAwesomeHelper.DefaultIconPack;
	public Styles FontAwesomeStyle { get; set; } = FontAwesomeHelper.DefaultStyle;
	public Dictionary<string, string> Translations { get; set; } = [];

	internal int FontAwesomeFlags => FontAwesomeHelper.ToInt32(FontAwesomeIconPack, FontAwesomeStyle);
}
