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

    #region Affected characters

    public static ConfigEntry<bool> MainCharacter;
    public static ConfigEntry<bool> Faction;
    public static ConfigEntry<bool> Party;
    public static ConfigEntry<bool> PlayerMinion;
    public static ConfigEntry<bool> FactionMinion;
    public static ConfigEntry<bool> PartyMinion;

    private static void MainCharacterConfig(ConfigFile config)
    {
        const bool defaultValue = true;

        var definition = new ConfigDefinition("Affected characters", "Player character");
        var description = new ConfigDescription("Is main character will be affected.");
        MainCharacter = config.Bind(definition, defaultValue, description);
    }

    private static void FactionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("Affected characters", "Player faction");
        var description = new ConfigDescription("Is player faction will be affected.");
        Faction = config.Bind(definition, defaultValue, description);
    }

    private static void PartyConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("Affected characters", "Player party");
        var description = new ConfigDescription("Is player party will be affected.");
        Party = config.Bind(definition, defaultValue, description);
    }

    private static void PlayerMinionConfig(ConfigFile config)
    {
        const bool defaultValue = true;

        var definition = new ConfigDefinition("Affected characters", "Player minion");
        var description = new ConfigDescription("Is player pinion will be affected.");
        PlayerMinion = config.Bind(definition, defaultValue, description);
    }

    private static void FactionMinionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("Affected characters", "Player faction minion");
        var description = new ConfigDescription("Is player faction minion will be affected.");
        FactionMinion = config.Bind(definition, defaultValue, description);
    }

    private static void PartyMinionConfig(ConfigFile config)
    {
        const bool defaultValue = false;

        var definition = new ConfigDefinition("Affected characters", "Player party minion");
        var description = new ConfigDescription("Is player party minion will be affected.");
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
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Attributes");
        var description = new ConfigDescription("Multiplier for attributes experience gain.");
        ExperienceMultiplierMainAttributes = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillGeneralConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "General skills");
        var description = new ConfigDescription("Multiplier for general skills experience gain.");
        ExperienceMultiplierSkillGeneral = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillMindConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Mind skills");
        var description = new ConfigDescription("Multiplier for mind skills experience gain.");
        ExperienceMultiplierSkillMind = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillWeaponConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Weapon skills");
        var description = new ConfigDescription("Multiplier for weapon skills experience gain.");
        ExperienceMultiplierSkillWeapon = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillCombatConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Combat skills");
        var description = new ConfigDescription("Multiplier for combat skills experience gain.");
        ExperienceMultiplierSkillCombat = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillCraftConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Craft skills");
        var description = new ConfigDescription("Multiplier for craft skills experience gain.");
        ExperienceMultiplierSkillCraft = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillStealthConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Stealth skills");
        var description = new ConfigDescription("Multiplier for stealth skills experience gain.");
        ExperienceMultiplierSkillStealth = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSkillLaborConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Labor skills");
        var description = new ConfigDescription("Multiplier for labor skills experience gain.");
        ExperienceMultiplierSkillLabor = config.Bind(definition, defaultValue, description);
    }

    private static void ExperienceMultiplierSpellAbilityConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Experience multipliers", "Spell abilities skills");
        var description = new ConfigDescription("Multiplier for spell abilities skills experience gain.");
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
        const int defaultValue = 1000;

        var definition = new ConfigDefinition("Potential constants", "Max potential");
        var description = new ConfigDescription("Maximum potential value.");
        MaxPotential = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierMainAttributeConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "MainAttributes");
        var description = new ConfigDescription("Multiplier for main attributes potential gain.");

        PotentialMultiplierMainAttributes = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillGeneralConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "General skills");
        var description = new ConfigDescription("Multiplier for general skills potential gain.");
        PotentialMultiplierSkillGeneral = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillMindConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Mind skills");
        var description = new ConfigDescription("Multiplier for mind skills potential gain.");
        PotentialMultiplierSkillMind = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillWeaponConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Weapon skills");
        var description = new ConfigDescription("Multiplier for weapon skills potential gain.");
        PotentialMultiplierSkillWeapon = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillCombatConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Combat skills");
        var description = new ConfigDescription("Multiplier for combat skills potential gain.");
        PotentialMultiplierSkillCombat = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillCraftConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Craft skills");
        var description = new ConfigDescription("Multiplier for craft skills potential gain.");
        PotentialMultiplierSkillCraft = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillStealthConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Stealth skills");
        var description = new ConfigDescription("Multiplier for stealth skills potential gain.");
        PotentialMultiplierSkillStealth = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSkillLaborConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Labor skills");
        var description = new ConfigDescription("Multiplier for labor skills potential gain.");
        PotentialMultiplierSkillLabor = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialMultiplierSpellAbilityConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential multipliers", "Spell abilities skills");
        var description = new ConfigDescription("Multiplier for spell abilities skills potential gain.");
        PotentialMultiplierSpellAbility = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierMainAttributeConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Attributes");
        var description = new ConfigDescription("Multiplier for main attributes potential loss.");

        PotentialLossMultiplierMainAttributes = config.Bind(definition, defaultValue, description);
    }
    
    private static void PotentialLossMultiplierSkillGeneralConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "General skills");
        var description = new ConfigDescription("Multiplier for general skills potential loss.");
        PotentialLossMultiplierSkillGeneral = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillMindConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Mind skills");
        var description = new ConfigDescription("Multiplier for mind skills potential loss.");
        PotentialLossMultiplierSkillMind = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillWeaponConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Weapon skills");
        var description = new ConfigDescription("Multiplier for weapon skills potential loss.");
        PotentialLossMultiplierSkillWeapon = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillCombatConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Combat skills");
        var description = new ConfigDescription("Multiplier for combat skills potential loss.");
        PotentialLossMultiplierSkillCombat = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillCraftConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Craft skills");
        var description = new ConfigDescription("Multiplier for craft skills potential loss.");
        PotentialLossMultiplierSkillCraft = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillStealthConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Stealth skills");
        var description = new ConfigDescription("Multiplier for stealth skills potential loss.");
        PotentialLossMultiplierSkillStealth = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSkillLaborConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Labor skills");
        var description = new ConfigDescription("Multiplier for labor skills potential loss.");
        PotentialLossMultiplierSkillLabor = config.Bind(definition, defaultValue, description);
    }

    private static void PotentialLossMultiplierSpellAbilityConfig(ConfigFile config)
    {
        const float defaultValue = 1.0f;

        var definition = new ConfigDefinition("Potential loss multipliers", "Spell abilities skills");
        var description = new ConfigDescription("Multiplier for spell abilities skills potential loss.");
        PotentialLossMultiplierSpellAbility = config.Bind(definition, defaultValue, description);
    }

    #endregion
}