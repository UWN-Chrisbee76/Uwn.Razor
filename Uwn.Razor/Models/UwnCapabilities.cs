using Microsoft.JSInterop;

namespace Uwn.Razor.Models;

// Not observable, as it is not meant to be modified on the fly
public sealed class UwnCapabilities
{
	public int? BootstrapMajorVersion { get; internal set; } = null;
	public bool IsFontAwesomeAvailable { get; internal set; } = false;
	public bool IsJqueryAvailable { get; internal set; } = false;
	public bool IsPopperAvailable { get; internal set; } = false;

	internal IJSObjectReference? JsModule { get; set; }
}
