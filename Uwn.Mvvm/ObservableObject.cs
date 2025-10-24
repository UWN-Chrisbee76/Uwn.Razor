using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Uwn.Mvvm;

public abstract class ObservableObject
	: INotifyPropertyChanging, INotifyPropertyChanged
{
	#region PropertyChanging

	public event PropertyChangingEventHandler? PropertyChanging;

	protected void OnPropertyChanging([CallerMemberName] string? propertyName = null)
		=> OnPropertyChanging(new PropertyChangingEventArgs(propertyName));
	protected virtual void OnPropertyChanging(PropertyChangingEventArgs e)
	{
		ArgumentNullException.ThrowIfNull(e);
		PropertyChanging?.Invoke(this, e);
	}

	#endregion // PropertyChanging

	#region PropertyChanged

	public event PropertyChangedEventHandler? PropertyChanged;

	protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
		=> OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
	protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
	{
		ArgumentNullException.ThrowIfNull(e);
		PropertyChanged?.Invoke(this, e);
	}

	#endregion // PropertyChanged

	#region SetField

	protected bool SetField<T>([NotNullIfNotNull(nameof(newValue))] ref T field, T newValue, [CallerMemberName] string? propertyName = null)
	{
		if (EqualityComparer<T>.Default.Equals(field, newValue))
			return false;

		OnPropertyChanging(propertyName);
		field = newValue;
		OnPropertyChanged(propertyName);

		return true;
	}

	protected bool SetField<T>([NotNullIfNotNull(nameof(newValue))] ref T field, T newValue, IEqualityComparer<T> comparer, [CallerMemberName] string? propertyName = null)
	{
		ArgumentNullException.ThrowIfNull(comparer);
		if (comparer.Equals(field, newValue))
			return false;

		OnPropertyChanging(propertyName);
		field = newValue;
		OnPropertyChanged(propertyName);

		return true;
	}

	protected bool SetField<T>(T oldValue, T newValue, Action<T> callback, [CallerMemberName] string? propertyName = null)
	{
		ArgumentNullException.ThrowIfNull(callback);
		if (EqualityComparer<T>.Default.Equals(oldValue, newValue))
			return false;

		OnPropertyChanging(propertyName);
		callback(newValue);
		OnPropertyChanged(propertyName);

		return true;
	}

	protected bool SetField<T>(T oldValue, T newValue, IEqualityComparer<T> comparer, Action<T> callback, [CallerMemberName] string? propertyName = null)
	{
		ArgumentNullException.ThrowIfNull(comparer);
		ArgumentNullException.ThrowIfNull(callback);
		if (comparer.Equals(oldValue, newValue))
			return false;

		OnPropertyChanging(propertyName);
		callback(newValue);
		OnPropertyChanged(propertyName);

		return true;
	}

	protected bool SetField<TModel, T>(T oldValue, T newValue, TModel model, Action<TModel, T> callback, [CallerMemberName] string? propertyName = null)
		where TModel : class
	{
		ArgumentNullException.ThrowIfNull(model);
		ArgumentNullException.ThrowIfNull(callback);
		if (EqualityComparer<T>.Default.Equals(oldValue, newValue))
			return false;

		OnPropertyChanging(propertyName);
		callback(model, newValue);
		OnPropertyChanged(propertyName);

		return true;
	}

	protected bool SetField<TModel, T>(T oldValue, T newValue, IEqualityComparer<T> comparer, TModel model, Action<TModel, T> callback, [CallerMemberName] string? propertyName = null)
		where TModel : class
	{
		ArgumentNullException.ThrowIfNull(comparer);
		ArgumentNullException.ThrowIfNull(model);
		ArgumentNullException.ThrowIfNull(callback);
		if (comparer.Equals(oldValue, newValue))
			return false;

		OnPropertyChanging(propertyName);
		callback(model, newValue);
		OnPropertyChanged(propertyName);

		return true;
	}

	#endregion // SetField
}
