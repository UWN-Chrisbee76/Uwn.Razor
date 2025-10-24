using Microsoft.AspNetCore.Components;
using Uwn.Razor.Models.ViewModels;

namespace Uwn.Razor.Components;

public abstract class UwnComponentWithRouteBase<TViewModel>
	: UwnComponentBase<TViewModel>
	where TViewModel : RouteViewModel, new()
{
	// TODO this must be included in the ViewModels

	[Parameter] public string Route { get; set; } = string.Empty;
	[Parameter] public string? IdString { get; set; }

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

	protected override void SetViewModelParameters()
	{
		base.SetViewModelParameters();
		ViewModel.Route = Route;
		ViewModel.IdString = IdString;
	}
}