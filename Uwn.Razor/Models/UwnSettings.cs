using Uwn.Razor.Enumerations.FontAwesome;

namespace Uwn.Razor.Models;

// Not observable, as it is not meant to be modified on the fly
public sealed class UwnSettings
{
	public IconPacks FontAwesomeIconPack { get; set; } = FontAwesomeHelper.DefaultIconPack;
	public Styles FontAwesomeStyle { get; set; } = FontAwesomeHelper.DefaultStyle;
	public Dictionary<string, string> Translations { get; set; } = [];

	public int FontAwesomeFlags => FontAwesomeHelper.ToInt32(FontAwesomeIconPack, FontAwesomeStyle);
}
