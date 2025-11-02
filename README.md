# Localization Lib for Duckov

This mod is used for easier localization in Duckov mods.

## Usage

Call `ModTypeProvider.RegisterModType()` in your mod's OnEnable method to register your mod type.

Use the same format as Duckov's builtin localization system:
Put a Localization folder under your mod's folder, then create different language csv files with the same format in official game.
Then you should be able to just use the game's extension methods to get localized text.

**Default Fallback Language**: English