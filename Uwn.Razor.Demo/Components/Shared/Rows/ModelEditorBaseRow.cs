using Microsoft.AspNetCore.Components;
using Uwn.Mvvm;

namespace Uwn.Razor.Demo.Components.Shared.Rows;

public class ModelEditorBaseRow<TModel>
	: ComponentBase
	where TModel : ObservableObject, new()
{
#pragma warning disable BL0007 // Component parameter '...' should be auto property
	private TModel? _value = new();
	[Parameter]
	public TModel? Value
	{
		get => _value;
		set
		{
			if (value != _value)
			{
				_value = value;
				ValueChanged.InvokeAsync(_value);
				if (_value is not null)
					_value.PropertyChanged += (_, _) => ValueChanged.InvokeAsync(_value);
			}
		}
	}
#pragma warning restore BL0007

	[Parameter] public EventCallback<TModel?> ValueChanged { get; set; }
}
