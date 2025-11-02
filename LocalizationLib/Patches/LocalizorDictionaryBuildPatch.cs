namespace LocalizationLib.Patches;

[HarmonyPatch(typeof(CSVFileLocalizor), nameof(CSVFileLocalizor.BuildDictionary))]
internal static class LocalizorDictionaryBuildPatch
{
    private static void Postfix(CSVFileLocalizor __instance) =>
        LocalizationLoader.LoadLanguage(__instance, __instance.Language);
}