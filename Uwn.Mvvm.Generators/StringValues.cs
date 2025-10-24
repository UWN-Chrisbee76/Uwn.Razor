namespace Uwn.Mvvm.Generators;

internal static class StringValues
{
	internal const string AttributesNamespace = "Uwn.Mvvm";
	internal const string BaseTypesNamespace = "Uwn.Mvvm";

	internal const string ObservableObjectAttributeName = "ObservableObjectAttribute";
	internal const string ObservablePropertyAttributeName = "ObservablePropertyAttribute";

	internal const string ObservableObjectAttributeFullyQualifiedName = AttributesNamespace + "." + ObservableObjectAttributeName;
	internal const string ObservablePropertyAttributeFullyQualifiedName = AttributesNamespace + "." + ObservablePropertyAttributeName;

	internal const string ObservableObjectName = "ObservableObject";
	internal const string ObservableObjectFullyQualifiedName = BaseTypesNamespace + "." + "ObservableObject";

	internal const string ObservableObjectGeneratorIdPrefix = "OOG";
	internal const string ObservablePropertyGeneratorIdPrefix = "OPG";

	internal const string ObservableObjectGeneratorName = "ObservableObjectGenerator";
	internal const string ObservablePropertyGeneratorName = "ObservablePropertyGenerator";
}
