using Uwn.Mvvm;
using Uwn.Razor.Enumerations.Bootstrap;

namespace Uwn.Razor.Models.ViewModels.Bootstrap.Tables;

public sealed partial class TableViewModel
	: ChildContentViewModel
{
	[ObservableProperty] private TablePurpose _purpose = TablePurpose.Editor;
}
