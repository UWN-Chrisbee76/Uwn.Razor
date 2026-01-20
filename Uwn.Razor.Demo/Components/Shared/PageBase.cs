using System.ComponentModel;
using Microsoft.AspNetCore.Components;
using Uwn.Razor.Models.ViewModels;

namespace Uwn.Razor.Demo.Components.Shared;

public abstract class PageBase<TViewModel>
	: ComponentBase, IDisposable
	where TViewModel : BaseViewModel, new()
{
	protected readonly TViewModel ViewModel = new();

	protected override void OnInitialized()
	{
		base.OnInitialized();
		InitializeViewModel();
		ViewModel.PropertyChanged += OnViewModelPropertyChanged;
	}

	protected abstract void InitializeViewModel();

	public void Dispose()
	{
		ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
		GC.SuppressFinalize(this);
	}

	private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
	{
		if (ViewModel.IsVisible || e.PropertyName == nameof(ViewModel.IsVisible))
			InvokeAsync(StateHasChanged);
	}
}
