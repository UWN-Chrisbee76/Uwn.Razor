using Microsoft.CodeAnalysis;

namespace Uwn.Mvvm.Generators;

internal static class SourceProductionContextExtender
{
	internal static void ReportDiagnostic(this SourceProductionContext context, string prefix, int id, DiagnosticSeverity severity, string title, string messageFormat, params string[] messageArgs)
		=> context.ReportDiagnostic(prefix, id, severity, Location.None, title, messageFormat, messageArgs);

	internal static void ReportDiagnostic(this SourceProductionContext context, string prefix, int id, DiagnosticSeverity severity, Location location, string title, string messageFormat, params string[] messageArgs)
		=> context.ReportDiagnostic(DiagnosticFactory.CreateDiagnostic(prefix, id, severity, location, title, messageFormat, messageArgs));
}
