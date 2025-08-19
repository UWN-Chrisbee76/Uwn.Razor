using Microsoft.JSInterop;

namespace Uwn.Razor.Models;

public sealed class UwnCapabilities
{
	public int? BootstrapMajorVersion { get; internal set; } = null;
	public bool IsFontAwesomeAvailable { get; internal set; } = false;
	public bool IsJqueryAvailable { get; internal set; } = false;
	public bool IsPopperAvailable { get; internal set; } = false;

	internal IJSObjectReference? JsModule { get; set; }
}
