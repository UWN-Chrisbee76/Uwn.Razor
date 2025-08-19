using Microsoft.JSInterop;
using Uwn.Razor.Models;

namespace Uwn.Razor.Services;

public sealed class UwnCapabilitiesService
{
	public async Task<UwnCapabilities> InitializeAsync(IJSRuntime JsRuntime) // Do NOT make this static, it will break
	{
		var capabilities = new UwnCapabilities
		{
			JsModule = await JsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Uwn.Razor/js/uwnComponentUtils.js")
		};
		capabilities.BootstrapMajorVersion = await capabilities.JsModule.InvokeAsync<int>("getBootstrapMajorVersion", null);
		capabilities.IsFontAwesomeAvailable = await capabilities.JsModule.InvokeAsync<bool>("checkFontAwesome", null);
		capabilities.IsJqueryAvailable = await capabilities.JsModule.InvokeAsync<bool>("checkJquery", null);
		capabilities.IsPopperAvailable = await capabilities.JsModule.InvokeAsync<bool>("checkPopper", null);
		return capabilities;
	}
}
