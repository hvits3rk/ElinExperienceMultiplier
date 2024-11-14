using System;
using BepInEx.Configuration;

namespace ExperienceMultiplier;

public class PluginSettings
{
    private const float MinExperienceMultiplierAcceptableValue = 0.1f;
    private const float MaxExperienceMultiplierAcceptableValue = 1000.0f;
    private const float DefaultExperienceValue = 2.0f;
    public static ConfigEntry<float> ExperienceMultiplier;

    private const int MinPotentialAcceptableValue = 10;
    private const int MaxPotentialAcceptableValue = Int32.MaxValue;
    private const int DefaultMaxPotentialValue = 1000;
    public static ConfigEntry<int> MaxPotential;

    private const float MinPotentialMultiplierAcceptableValue = 0.1f;
    private const float MaxPotentialMultiplierAcceptableValue = 1000.0f;
    private const float DefaultPotentialMultiplierValue = 1.0f;
    public static ConfigEntry<float> PotentialMultiplier;

    public static ConfigEntry<bool> MainCharacter;
    public static ConfigEntry<bool> Faction;
    public static ConfigEntry<bool> Party;
    public static ConfigEntry<bool> PlayerMinion;
    public static ConfigEntry<bool> FactionMinion;
    public static ConfigEntry<bool> PartyMinion;

    public static void InitializeConfiguration(ConfigFile config)
    {
        var expDefinition = new ConfigDefinition("General", "ExperienceMultiplier");
        var expDescription = new ConfigDescription("Multiplier for experience gain.",
            new AcceptableValueRange<float>(MinExperienceMultiplierAcceptableValue, MaxExperienceMultiplierAcceptableValue));
        ExperienceMultiplier = config.Bind(expDefinition, DefaultExperienceValue, expDescription);

        var maxPotentialDefinition = new ConfigDefinition("General", "MaxPotential");
        var maxPotentialDescription = new ConfigDescription("Maximum potential value.",
            new AcceptableValueRange<int>(MinPotentialAcceptableValue, MaxPotentialAcceptableValue));
        MaxPotential = config.Bind(maxPotentialDefinition, DefaultMaxPotentialValue, maxPotentialDescription);

        var potentialMultiplierDefinition = new ConfigDefinition("General", "PotentialMultiplier");
        var potentialMultiplierDescription = new ConfigDescription("Multiplier for potential gain.",
            new AcceptableValueRange<float>(MinPotentialMultiplierAcceptableValue, MaxPotentialMultiplierAcceptableValue));
        PotentialMultiplier = config.Bind(potentialMultiplierDefinition, DefaultPotentialMultiplierValue, potentialMultiplierDescription);

        var mainCharacterTypeDefinition = new ConfigDefinition("CharacterType", "MainCharacter");
        var mainCharacterTypeDescription = new ConfigDescription("Is Main Character will be affected.");
        MainCharacter = config.Bind(mainCharacterTypeDefinition, true, mainCharacterTypeDescription);

        var factionTypeDefinition = new ConfigDefinition("CharacterType", "Faction");
        var factionTypeDescription = new ConfigDescription("Is Player Faction will be affected.");
        Faction = config.Bind(factionTypeDefinition, false, factionTypeDescription);

        var partyTypeDefinition = new ConfigDefinition("CharacterType", "Party");
        var partyTypeDescription = new ConfigDescription("Is Player Party will be affected.");
        Party = config.Bind(partyTypeDefinition, false, partyTypeDescription);

        var playerMinionTypeDefinition = new ConfigDefinition("CharacterType", "PlayerMinion");
        var playerMinionTypeDescription = new ConfigDescription("Is Player Minion will be affected.");
        PlayerMinion = config.Bind(playerMinionTypeDefinition, false, playerMinionTypeDescription);

        var factionMinionTypeDefinition = new ConfigDefinition("CharacterType", "FactionMinion");
        var factionMinionTypeDescription = new ConfigDescription("Is Faction Minion will be affected.");
        FactionMinion = config.Bind(factionMinionTypeDefinition, false, factionMinionTypeDescription);

        var partyMinionTypeDefinition = new ConfigDefinition("CharacterType", "PartyMinion");
        var partyMinionTypeDescription = new ConfigDescription("Is Party Minion will be affected.");
        PartyMinion = config.Bind(partyMinionTypeDefinition, false, partyMinionTypeDescription);
    }
}