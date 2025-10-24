using Microsoft.AspNetCore.Components;
using Uwn.Razor.Enumerations.FontAwesome;

namespace Uwn.Razor.Services;

public static class FragmentProvider
{
	public static RenderFragment BuildFontAwesomeFragment(string iconClassName, string? additionalClassNames = null)
		=> BuildFontAwesomeFragment(FontAwesomeHelper.Flags, iconClassName, additionalClassNames);

	public static RenderFragment BuildFontAwesomeFragment(int flags, string iconClassName, string? additionalClassNames = null)
		=> builder =>
		{
			if (!string.IsNullOrWhiteSpace(iconClassName))
			{
				var classNames = FontAwesomeHelper.GetClassNames(flags, iconClassName, additionalClassNames);
				builder.OpenElement(0, "i");
				builder.AddAttribute(1, "class", $"{classNames}");
				builder.CloseElement();
			}
		};

	//

	[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "ASP0006: Do not use non-literal sequence numbers", Justification = "No other way to do it")]
	public static RenderFragment BuildFormattedContent(string? content, int? maxLines = null)
		=> builder =>
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
}