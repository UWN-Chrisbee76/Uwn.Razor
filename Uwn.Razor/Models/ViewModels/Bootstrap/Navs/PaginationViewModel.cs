using Microsoft.AspNetCore.Components;
using Uwn.Mvvm;

namespace Uwn.Razor.Models.ViewModels.Bootstrap.Navs;

public sealed partial class PaginationViewModel
	: BaseViewModel
{
	[ObservableProperty] private int _currentPage = 1;
	[ObservableProperty] private int _numberOfPages;
	[ObservableProperty] private int _maximumNumberOfLinks = 11;
	[ObservableProperty] private EventCallback<int> _onPageSelected;
}
