namespace Uwn.Mvvm;

[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class ObservablePropertyAttribute
	: Attribute
{
	// No body - this is used for the source generator only
}
