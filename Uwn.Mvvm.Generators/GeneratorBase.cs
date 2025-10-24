using System.Text;
using Microsoft.CodeAnalysis;

namespace Uwn.Mvvm.Generators;

public abstract class GeneratorBase
{
	internal static string? BuildPropertyName(IFieldSymbol? fieldSymbol) // "_fieldName" will become "FieldName"
		=> fieldSymbol is null || fieldSymbol.Name.Length < 3 ? null : char.ToUpper(fieldSymbol.Name[1]) + fieldSymbol.Name.Substring(2);

	internal static string BuildFilename(INamespaceSymbol namespaceSymbol, INamedTypeSymbol namedTypeSymbol, IFieldSymbol? fieldSymbol)
		=> BuildFilename(namespaceSymbol.Name, namedTypeSymbol.Name, BuildPropertyName(fieldSymbol));

	internal static string BuildFilename(string namespaceName, string typeName, string? propertyName = null)
	{
		namespaceName = namespaceName.Replace('.', '_');
		var builder = new StringBuilder();
		builder.Append(namespaceName);
		builder.Append('_');
		builder.Append(typeName);
		if (propertyName is not null)
		{
			builder.Append('_');
			builder.Append(propertyName);
		}
		builder.Append(".g.cs");
		return builder.ToString();
	}
}
