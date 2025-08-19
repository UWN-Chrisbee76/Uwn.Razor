using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Uwn.Razor.Enumerations.FontAwesome;
using Uwn.Razor.Models;

namespace Uwn.Razor.Components;

public abstract class UwnComponentBase : ComponentBase
{
	[Inject] public IStringLocalizerFactory? LocalizerFactory { get; set; }
	private IStringLocalizer? _localizer;
	protected IStringLocalizer Localizer
	{
		get
		{
			_localizer ??= LocalizerFactory!.Create("Uwn.Razor.Resources.TextResources", "Uwn.Razor");
			return _localizer!;
		}
	}

	[Parameter] public string? AdditionalClassNames { get; set; }
	[Parameter] public string? Id { get; set; } = Guid.NewGuid().ToString();
	[Parameter] public bool IsVisible { get; set; } = true;

	[CascadingParameter] public UwnCapabilities? Capabilities { get; set; }
	[CascadingParameter] public UwnSettings? Settings { get; set; }

	protected bool UsesTooltips { get; set; } = false;

	protected int FontAwesomeFlags => Settings is null ? FontAwesomeHelper.DefaultFlags : Settings.FontAwesomeFlags;
	protected bool IsBootstrapAvailable => Capabilities?.BootstrapMajorVersion is not null;
	protected bool IsFontAwesomeAvailable => Capabilities?.IsFontAwesomeAvailable == true;

	private bool _doInitializeTooltips = true;

	//

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (_doInitializeTooltips &&
			UsesTooltips &&
			Capabilities is not null &&
			Capabilities.BootstrapMajorVersion >= 5
			&& Capabilities.JsModule is not null)
		{
			_doInitializeTooltips = false;
			await Capabilities.JsModule.InvokeVoidAsync("initializeTooltips", null);
		}
	}

	//

	protected RenderFragment BuildFontAwesomeElement(string iconClassName)
		=> BuildFontAwesomeElement(iconClassName, AdditionalClassNames);
	protected RenderFragment BuildFontAwesomeElement(string iconClassName, string? additionalClassNames = null) => builder =>
	{
		if (IsFontAwesomeAvailable)
		{
			builder.OpenElement(0, "i");
			builder.AddAttribute(1, "class", $"{GetFontAwesomeClassNames(iconClassName, additionalClassNames)}");
			builder.CloseElement();
		}
	};

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "ASP0006:Do not use non-literal sequence numbers", Justification = "No other way to do it")]
	protected static RenderFragment BuildFormattedContent(string? content, int? maxLines = null) => builder =>
	{
		if (content is null) return;
		var lines = content.Split(["\r\n", "\r", "\n", "<br>", "<br/>", "<br />", "<BR>", "<BR/>", "<BR />"], StringSplitOptions.None).ToList();
		if (maxLines is not null && lines.Count > maxLines)
		{
			while (lines.Count > (maxLines - 1))
				lines.RemoveAt(lines.Count / 2);
			lines.Insert(lines.Count / 2, "...");
		}
		var index = 0;
		foreach (var line in lines)
		{
			builder.OpenElement(index++, "span");
			builder.AddContent(index++, line);
			builder.CloseElement();
			builder.AddMarkupContent(index++, "<br />");
		}
	};

	protected string GetFontAwesomeClassNames(string iconClassName, string? additionalClassNames = null)
		=> $"{FontAwesomeHelper.GetClassNames(FontAwesomeFlags)} {iconClassName} {additionalClassNames}".Trim();

	protected string GetTranslation(string name)
	{
		if (Settings is not null && Settings.Translations is not null && Settings.Translations.TryGetValue(name, out var value)) return value;
		else if (Localizer is null) return $"('{name}')";
		else return Localizer.GetString(name);
	}
}