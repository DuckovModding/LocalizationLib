using MiniExcelLibs;
using MiniLocalizor;
using UnityEngine;

namespace LocalizationLib;

internal static class LocalizationLoader
{
    private const string LocalizationFolder = "Localization";
    private const string FallbackLanguage = "English";

    internal static void LoadLanguage(CSVFileLocalizor localizor, SystemLanguage language)
    {
        try
        {
            var dict = Traverse.Create(localizor).Field<Dictionary<string, DataEntry>>("dic").Value;

            foreach (var modPath in ModTypeProvider.ModTypes
                         .Select(type => Path.GetDirectoryName(type.Assembly.Location)))
            {
                var languagePath = Path.Combine(modPath!, LocalizationFolder, $"{language}.csv");
                if (!File.Exists(languagePath))
                {
                    languagePath = Path.Combine(modPath, LocalizationFolder, $"{FallbackLanguage}.csv");
                }

                using var fileStream = File.OpenRead(languagePath);

                foreach (var dataEntry in fileStream.Query<DataEntry>(null, ExcelType.CSV))
                {
                    if (dataEntry != null && !string.IsNullOrEmpty(dataEntry.key))
                    {
                        dict[dataEntry.key] = dataEntry;
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Debug.LogException(ex);
            Debug.LogError("LocalizationLib: Failed to load custom localization file.");
        }
    }
}