using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Uwn.Razor.Models.ViewModels;

namespace Uwn.Razor.Providers;

public abstract class ProviderBase<TViewModel>
	: ComponentBase, IDisposable
	where TViewModel : BaseViewModel, new()
{
	protected readonly TViewModel _ViewModel = new();

	[Parameter] public RenderFragment? ChildContent { get; set; }

	public void Dispose()
	{
		_ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
		GC.SuppressFinalize(this);
	}

	protected override void OnInitialized()
	{
		base.OnInitialized();
		_ViewModel.Id = GetDefaultId();
		_ViewModel.PropertyChanged += OnViewModelPropertyChanged;
	}

	protected abstract string GetDefaultId();

	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (_ViewModel.IsVisible || e.PropertyName == nameof(_ViewModel.IsVisible))
			InvokeAsync(StateHasChanged);
	}
}
