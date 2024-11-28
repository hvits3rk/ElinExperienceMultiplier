using System;
using BepInEx.Configuration;

namespace ExperienceMultiplier;

public class PluginSettings
{
    public static void InitializeConfiguration(ConfigFile config)
    {
        MainCharacterConfig(config);
        FactionConfig(config);
        PartyConfig(config);
        PlayerMinionConfig(config);
        FactionMinionConfig(config);
        PartyMinionConfig(config);

        ExperienceMultiplierMainAttributeConfig(config);
        ExperienceMultiplierSkillGeneralConfig(config);
        ExperienceMultiplierSkillMindConfig(config);
        ExperienceMultiplierSkillWeaponConfig(config);
        ExperienceMultiplierSkillCombatConfig(config);
        ExperienceMultiplierSkillCraftConfig(config);
        ExperienceMultiplierSkillStealthConfig(config);
        ExperienceMultiplierSkillLaborConfig(config);
        ExperienceMultiplierSpellAbilityConfig(config);

        MaxPotentialConfig(config);

        PotentialMultiplierMainAttributeConfig(config);
        PotentialMultiplierSkillGeneralConfig(config);
        PotentialMultiplierSkillMindConfig(config);
        PotentialMultiplierSkillWeaponConfig(config);
        PotentialMultiplierSkillCombatConfig(config);
        PotentialMultiplierSkillCraftConfig(config);
        PotentialMultiplierSkillStealthConfig(config);
        PotentialMultiplierSkillLaborConfig(config);
        PotentialMultiplierSpellAbilityConfig(config);

        PotentialLossMultiplierMainAttributeConfig(config);
        PotentialLossMultiplierSkillGeneralConfig(config);
        PotentialLossMultiplierSkillMindConfig(config);
        PotentialLossMultiplierSkillWeaponConfig(config);
        PotentialLossMultiplierSkillCombatConfig(config);
        PotentialLossMultiplierSkillCraftConfig(config);
        PotentialLossMultiplierSkillStealthConfig(config);
        PotentialLossMultiplierSkillLaborConfig(config);
        PotentialLossMultiplierSpellAbilityConfig(config);
    }

    #region CharacterType

    public static ConfigEntry<bool> MainCharacter;
    public static ConfigEntry<bool> Faction;
    public static ConfigEntry<bool> Party;
    public static ConfigEntry<bool> PlayerMinion;
    public static ConfigEntry<bool> FactionMinion;
    public static ConfigEntry<bool> PartyMinion;

    private static void MainCharacterConfig(ConfigFile config)
    {
        const bool defaultValue = true;

        var definition = new ConfigDefinition("CharacterType", "MainCharacter");
        var description = new ConfigDescription("Is Main Character will be affected.");
        MainCharacter = config.Bind(definition, defaultValue, description);
    }

    private static void FactionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("CharacterType", "Faction");
        var description = new ConfigDescription("Is Player Faction will be affected.");
        Faction = config.Bind(definition, defaultValue, description);
    }

    private static void PartyConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("CharacterType", "Party");
        var description = new ConfigDescription("Is Player Party will be affected.");
        Party = config.Bind(definition, defaultValue, description);
    }

    private static void PlayerMinionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("CharacterType", "PlayerMinion");
        var description = new ConfigDescription("Is Player Minion will be affected.");
        PlayerMinion = config.Bind(definition, defaultValue, description);
    }

    private static void FactionMinionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("CharacterType", "FactionMinion");
        var description = new ConfigDescription("Is Faction Minion will be affected.");
        FactionMinion = config.Bind(definition, defaultValue, description);
    }

    private static void PartyMinionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("CharacterType", "PartyMinion");
        var description = new ConfigDescription("Is Party Minion will be affected.");
        PartyMinion = config.Bind(definition, defaultValue, description);
    }

    #endregion

    #region Experience

    public static ConfigEntry<float> ExperienceMultiplierMainAttributes;
    public static ConfigEntry<float> ExperienceMultiplierSkillGeneral;
    public static ConfigEntry<float> ExperienceMultiplierSkillMind;
    public static ConfigEntry<float> ExperienceMultiplierSkillWeapon;
    public static ConfigEntry<float> ExperienceMultiplierSkillCombat;
    public static ConfigEntry<float> ExperienceMultiplierSkillCraft;
    public static ConfigEntry<float> ExperienceMultiplierSkillStealth;
    public static ConfigEntry<float> ExperienceMultiplierSkillLabor;
    public static ConfigEntry<float> ExperienceMultiplierSpellAbility;

    private static void ExperienceMultiplierMainAttributeConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "MainAttributes");
        var description = new ConfigDescription("Multiplier for main attributes experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierMainAttributes = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillGeneralConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillGeneral");
        var description = new ConfigDescription("Multiplier for general skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillGeneral = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillMindConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillMind");
        var description = new ConfigDescription("Multiplier for mind skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillMind = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillWeaponConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillWeapon");
        var description = new ConfigDescription("Multiplier for weapon skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillWeapon = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillCombatConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillCombat");
        var description = new ConfigDescription("Multiplier for combat skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillCombat = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillCraftConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillCraft");
        var description = new ConfigDescription("Multiplier for craft skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillCraft = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillStealthConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillStealth");
        var description = new ConfigDescription("Multiplier for stealth skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillStealth = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillLaborConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SkillLabor");
        var description = new ConfigDescription("Multiplier for labor skills experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSkillLabor = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSpellAbilityConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 2.0f;

        var definition = new ConfigDefinition("ExperienceMultiplier", "SpellAbility");
        var description = new ConfigDescription("Multiplier for spell abilities experience gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        ExperienceMultiplierSpellAbility = config.Bind(definition, defaultValue, description);
    }

    #endregion

    #region Potential

    public static ConfigEntry<int> MaxPotential;

    public static ConfigEntry<float> PotentialMultiplierMainAttributes;
    public static ConfigEntry<float> PotentialMultiplierSkillGeneral;
    public static ConfigEntry<float> PotentialMultiplierSkillMind;
    public static ConfigEntry<float> PotentialMultiplierSkillWeapon;
    public static ConfigEntry<float> PotentialMultiplierSkillCombat;
    public static ConfigEntry<float> PotentialMultiplierSkillCraft;
    public static ConfigEntry<float> PotentialMultiplierSkillStealth;
    public static ConfigEntry<float> PotentialMultiplierSkillLabor;
    public static ConfigEntry<float> PotentialMultiplierSpellAbility;

    public static ConfigEntry<float> PotentialLossMultiplierMainAttributes;
    public static ConfigEntry<float> PotentialLossMultiplierSkillGeneral;
    public static ConfigEntry<float> PotentialLossMultiplierSkillMind;
    public static ConfigEntry<float> PotentialLossMultiplierSkillWeapon;
    public static ConfigEntry<float> PotentialLossMultiplierSkillCombat;
    public static ConfigEntry<float> PotentialLossMultiplierSkillCraft;
    public static ConfigEntry<float> PotentialLossMultiplierSkillStealth;
    public static ConfigEntry<float> PotentialLossMultiplierSkillLabor;
    public static ConfigEntry<float> PotentialLossMultiplierSpellAbility;

    private static void MaxPotentialConfig(ConfigFile config)
    {
        const int minDefault = 10;
        const int maxDefault = Int32.MaxValue;
        const int defaultValue = 1000;

        var definition = new ConfigDefinition("Potential", "MaxPotential");
        var description = new ConfigDescription("Maximum potential value.",
            new AcceptableValueRange<int>(minDefault, maxDefault));
        MaxPotential = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierMainAttributeConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "MainAttributes");
        var description = new ConfigDescription("Multiplier for main attributes potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));

        PotentialMultiplierMainAttributes = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillGeneralConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillGeneral");
        var description = new ConfigDescription("Multiplier for general skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillGeneral = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillMindConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillMind");
        var description = new ConfigDescription("Multiplier for mind skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillMind = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillWeaponConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillWeapon");
        var description = new ConfigDescription("Multiplier for weapon skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillWeapon = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillCombatConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillCombat");
        var description = new ConfigDescription("Multiplier for combat skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillCombat = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillCraftConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillCraft");
        var description = new ConfigDescription("Multiplier for craft skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillCraft = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillStealthConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillStealth");
        var description = new ConfigDescription("Multiplier for stealth skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillStealth = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillLaborConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SkillLabor");
        var description = new ConfigDescription("Multiplier for labor skills potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSkillLabor = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSpellAbilityConfig(ConfigFile config)
    {
        const float minDefault = 0.1f;
        const float maxDefault = 1000.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialMultiplier", "SpellAbility");
        var description = new ConfigDescription("Multiplier for spell abilities potential gain.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialMultiplierSpellAbility = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierMainAttributeConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "MainAttributes");
        var description = new ConfigDescription("Multiplier for main attributes potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));

        PotentialLossMultiplierMainAttributes = config.Bind(definition, defaultValue, description);
    }
    
    private static void PotentialLossMultiplierSkillGeneralConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillGeneral");
        var description = new ConfigDescription("Multiplier for general skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillGeneral = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillMindConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillMind");
        var description = new ConfigDescription("Multiplier for mind skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillMind = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillWeaponConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillWeapon");
        var description = new ConfigDescription("Multiplier for weapon skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillWeapon = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillCombatConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillCombat");
        var description = new ConfigDescription("Multiplier for combat skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillCombat = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillCraftConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillCraft");
        var description = new ConfigDescription("Multiplier for craft skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillCraft = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillStealthConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillStealth");
        var description = new ConfigDescription("Multiplier for stealth skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillStealth = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillLaborConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SkillLabor");
        var description = new ConfigDescription("Multiplier for labor skills potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSkillLabor = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSpellAbilityConfig(ConfigFile config)
    {
        const float minDefault = 0.0f;
        const float maxDefault = 10.0f;
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("PotentialLossMultiplier", "SpellAbility");
        var description = new ConfigDescription("Multiplier for spell abilities potential loss.",
            new AcceptableValueRange<float>(minDefault, maxDefault));
        PotentialLossMultiplierSpellAbility = config.Bind(definition, defaultValue, description);
    }

    #endregion
}