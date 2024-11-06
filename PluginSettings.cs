using BepInEx.Configuration;

namespace ExperienceMultiplier;

public class PluginSettings
{
    private const float MinAcceptableValue = 0.1f;
    private const float MaxAcceptableValue = 1000.0f;
    private const float DefaultValue = 2.0f;

    public static ConfigEntry<float> ExperienceMultiplier;
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
            new AcceptableValueRange<float>(MinAcceptableValue, MaxAcceptableValue));
        ExperienceMultiplier = config.Bind(expDefinition, DefaultValue, expDescription);

        var mainCharacterTypeDefinition = new ConfigDefinition("CharacterType", "MainCharacter");
        var mainCharacterTypeDescription = new ConfigDescription("Is Main Character experience will be multiplied.");
        MainCharacter = config.Bind(mainCharacterTypeDefinition, true, mainCharacterTypeDescription);

        var factionTypeDefinition = new ConfigDefinition("CharacterType", "Faction");
        var factionTypeDescription = new ConfigDescription("Is Player Faction experience will be multiplied.");
        Faction = config.Bind(factionTypeDefinition, false, factionTypeDescription);

        var partyTypeDefinition = new ConfigDefinition("CharacterType", "Party");
        var partyTypeDescription = new ConfigDescription("Is Player Party experience will be multiplied.");
        Party = config.Bind(partyTypeDefinition, false, partyTypeDescription);

        var playerMinionTypeDefinition = new ConfigDefinition("CharacterType", "PlayerMinion");
        var playerMinionTypeDescription = new ConfigDescription("Is Player Minion experience will be multiplied.");
        PlayerMinion = config.Bind(playerMinionTypeDefinition, false, playerMinionTypeDescription);

        var factionMinionTypeDefinition = new ConfigDefinition("CharacterType", "FactionMinion");
        var factionMinionTypeDescription = new ConfigDescription("Is Faction Minion experience will be multiplied.");
        FactionMinion = config.Bind(factionMinionTypeDefinition, false, factionMinionTypeDescription);

        var partyMinionTypeDefinition = new ConfigDefinition("CharacterType", "PartyMinion");
        var partyMinionTypeDescription = new ConfigDescription("Is Party Minion experience will be multiplied.");
        PartyMinion = config.Bind(partyMinionTypeDefinition, false, partyMinionTypeDescription);
    }
}