using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Components;

namespace Uwn.Razor.Demo.Components.Shared.Editors;

public abstract class ModelEditorBase<TModel>
	: ComponentBase
{
	[Parameter] public TModel? Model { get; set; }
	[Parameter] public EventCallback<TModel?> ModelChanged { get; set; }

	[MemberNotNullWhen(true, nameof(Model))]
	protected bool HasModel
	{
		get => Model != null;
		set
		{
			if (value == HasModel)
				return;

			if (value)
				Model ??= Activator.CreateInstance<TModel>();
			else
				Model = default;

			_ = ModelChanged.InvokeAsync(Model);
		}
	}

	protected abstract string GetLabel();

	// Render the switch as a RenderFragment
	protected RenderFragment RenderSwitch => builder =>
	{
		builder.OpenComponent(0, typeof(ModelEditorSwitch<TModel>));
		builder.AddAttribute(1, nameof(ModelEditorSwitch<>.HasModel), HasModel);
		builder.AddAttribute(2, nameof(ModelEditorSwitch<>.HasModelChanged), EventCallback.Factory.Create<bool>(this, value => HasModel = value));
		builder.AddAttribute(3, nameof(ModelEditorSwitch<>.Label), GetLabel());
		builder.CloseComponent();
	};
}
