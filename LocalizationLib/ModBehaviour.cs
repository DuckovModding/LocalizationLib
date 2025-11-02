namespace LocalizationLib;

internal class ModBehaviour : Duckov.Modding.ModBehaviour
{
    private static readonly Harmony HarmonyInstance = new("LocalizationLib");

    private void OnEnable() => HarmonyInstance.PatchAll();
}