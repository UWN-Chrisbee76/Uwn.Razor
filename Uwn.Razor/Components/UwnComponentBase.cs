using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using Uwn.Razor.Enumerations.FontAwesome;
using Uwn.Razor.Models;
using Uwn.Razor.Models.ViewModels;

namespace Uwn.Razor.Components;

public abstract class UwnComponentBase<TViewModel>
	: ComponentBase
	where TViewModel : BaseViewModel, new()
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

	protected TViewModel ViewModel { get; set; } = new();

	[Parameter] public TViewModel? Model { get; set; }
	[Parameter] public string? AdditionalClassNames { get; set; }
	[Parameter] public string? Id { get; set; } = Guid.NewGuid().ToString();
	[Parameter] public bool IsVisible { get; set; } = true;

	[CascadingParameter] public UwnCapabilities? Capabilities { get; set; }
	[CascadingParameter] public UwnSettings? Settings { get; set; }

	protected bool UsesTooltips { get; set; } = false;

	protected bool IsBootstrapAvailable => Capabilities?.BootstrapMajorVersion is not null;
	protected bool IsFontAwesomeAvailable => Capabilities?.IsFontAwesomeAvailable == true;

	private bool _doInitializeTooltips = true;

	//

	protected override void OnInitialized()
	{
		base.OnInitialized();
		FontAwesomeHelper.Flags = Settings is null ? FontAwesomeHelper.DefaultFlags : Settings.FontAwesomeFlags;
	}

	protected override void OnParametersSet()
	{
		base.OnParametersSet();
		if (Model is not null)
			ViewModel = Model;
		else
		{
			ViewModel = BuildViewModelFromParameters();
			SetViewModelParameters();
		}
	}

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		await base.OnAfterRenderAsync(firstRender);
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

	protected abstract TViewModel BuildViewModelFromParameters();

	protected virtual void SetViewModelParameters()
	{
		ViewModel.AdditionalClassNames = AdditionalClassNames;
		ViewModel.Id = Id;
		ViewModel.IsVisible = IsVisible;
	}

	protected string GetTranslation(string name)
	{
		if (Settings is not null && Settings.Translations is not null && Settings.Translations.TryGetValue(name, out var value)) return value;
		else if (Localizer is null) return $"('{name}')";
		else return Localizer.GetString(name);
	}
}
