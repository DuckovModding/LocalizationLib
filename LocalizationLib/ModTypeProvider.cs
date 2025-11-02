namespace LocalizationLib;

public static class ModTypeProvider
{
    internal static List<Type> ModTypes { get; } = [];

    public static void RegisterModType(Type type)
    {
        ModTypes.Add(type);
    }
}