using Microsoft.CodeAnalysis;

namespace Uwn.Mvvm.Generators;

internal static class DiagnosticFactory
{
	internal static Diagnostic CreateDiagnostic(string prefix, int id, DiagnosticSeverity severity, string title, string messageFormat, params string[] messageArgs)
	=> CreateDiagnostic(prefix, id, severity, Location.None, title, messageFormat, messageArgs);

	internal static Diagnostic CreateDiagnostic(string prefix, int id, DiagnosticSeverity severity, Location location, string title, string messageFormat, params string[] messageArgs)
		=> Diagnostic.Create(
			new DiagnosticDescriptor($"{prefix}{id:0000}", title, messageFormat, severity.ToString(), severity, true),
			location,
			messageArgs);
}
