using System.Reflection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Localization;
using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class BaseViewModel
	: ObservableObject
{
	[Inject] IWebHostEnvironment? Environment { get; set; }
	[Inject] IStringLocalizerFactory? LocalizerFactory { get; set; }

	[ObservableProperty] private string? _additionalClassNames;
	[ObservableProperty] private string? _id;
	[ObservableProperty] private bool _isVisible = true;

	protected bool IsDevelopmentEnvironment => Environment?.IsDevelopment() ?? false;

	public virtual void Show()
		=> IsVisible = true;

	public virtual void Hide()
		=> IsVisible = false;

	public virtual async Task ShowAsync()
	{
		Show();
		await Task.Yield();
	}

	public virtual async Task HideAsync()
	{
		Hide();
		await Task.Yield();
	}

	public void Reset()
	{
		// Resets all strings and links to null / empty
		var properties = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
		foreach (var property in properties)
		{
			var isNullable = false;
			var propertyType = property.PropertyType;
			var underlyingType = Nullable.GetUnderlyingType(propertyType);
			if (underlyingType is not null)
			{
				isNullable = true;
				propertyType = underlyingType;
			}
			if ((propertyType == typeof(string) && property.Name != "Id") || propertyType == typeof(Link))
				property.SetValue(this, isNullable ? null : default);
		}
	}

	protected string? GetTranslation(string name)
	{
		if (LocalizerFactory is null) return null;
		var localizer = LocalizerFactory?.Create("Uwn.Razor.Resources.TextResources", "Uwn.Razor");
		if (localizer is null) return null;
		return localizer.GetString(name);
	}
}