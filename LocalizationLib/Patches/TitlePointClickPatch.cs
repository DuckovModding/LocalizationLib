using SodaCraft.Localizations;

namespace LocalizationLib.Patches;

[HarmonyPatch(typeof(Title), nameof(Title.OnPointerClick))]
internal static class TitlePointClickPatch
{
    private static void Postfix()
    {
        var languageSettings = LocalizationDatabase.Instance.GetEntry(LocalizationManager.CurrentLanguage);
        var provider = Traverse.Create(languageSettings).Field<CSVFileLocalizor>("_provider").Value;

        LocalizationLoader.LoadLanguage(provider, LocalizationManager.CurrentLanguage);
    }
}