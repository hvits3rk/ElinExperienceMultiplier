using BepInEx.Configuration;

namespace ExperienceMultiplier;

public class PluginSettings
{
    private const float MinAcceptableValue = 0.1f;
    private const float MaxAcceptableValue = 1000.0f;
    private const float DefaultValue = 2.0f;

    public static ConfigEntry<float> ExperienceMultiplier;

    public static void InitializeConfiguration(ConfigFile config)
    {
        var potentialDefinition = new ConfigDefinition("General","ExperienceMultiplier");
        var potentialDescription = new ConfigDescription("Multiplier for experience gain.", new AcceptableValueRange<float>(MinAcceptableValue, MaxAcceptableValue));
        ExperienceMultiplier = config.Bind(potentialDefinition, DefaultValue, potentialDescription);
    }
}
