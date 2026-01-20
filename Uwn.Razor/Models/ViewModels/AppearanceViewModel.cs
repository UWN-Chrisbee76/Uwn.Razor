namespace Uwn.Razor.Models.ViewModels;

public abstract partial class AppearanceViewModel
	: ContentViewModel
{
	//[ObservableProperty] private Appearance _appearance = new();

	private Appearance _appearance = new();
	public Appearance Appearance
	{
		get => _appearance;
		set
		{
			if (SetField(ref _appearance, value))
				SubscribeToAppearance(_appearance);
		}
	}

	public AppearanceViewModel()
		=> SubscribeToAppearance(_appearance);

	private void SubscribeToAppearance(Appearance appearance)
		=> appearance.PropertyChanged += (_, _) => OnPropertyChanged(nameof(Appearance));
}
