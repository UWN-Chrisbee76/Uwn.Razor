namespace Uwn.Razor.Demo.Logic;

public static class LanguageExtender
{
	public static string GetClassName(this Language language)
		=> $"language-{language.ToString().ToLower()}";
}
