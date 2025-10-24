using Microsoft.AspNetCore.Components;
using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels;

public abstract partial class ChildContentViewModel
	: BaseViewModel
{
	[ObservableProperty] private RenderFragment? _childContent;
}
