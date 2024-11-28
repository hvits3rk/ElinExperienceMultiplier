namespace ExperienceMultiplier.Extensions;

public static class ElementExtensions
{
    public static bool IsMainAttribute(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "attribute" && element.source.tag.Contains("primary");
    }

    public static bool IsSkillWeapon(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "weapon";
    }

    public static bool IsSkillCombat(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "combat";
    }

    public static bool IsSkillCraft(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "craft";
    }

    public static bool IsSkillGeneral(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "general";
    }

    public static bool IsSkillMind(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "mind";
    }

    public static bool IsSkillStealth(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "stealth";
    }

    public static bool IsSkillLabor(this Element element)
    {
        if (element.source == null) return false;
        return element.source.category == "skill" && element.source.categorySub == "labor";
    }

    public static bool IsSpellAbility(this Element element)
    {
        if (element.source == null) return false;
        return element.source.group == "SPELL" && element.source.category == "ability";
    }

    public static bool IsSpellAbilityBuff(this Element element)
    {
        if (element.source == null) return false;
        return element.source.group == "SPELL" && element.source.category == "ability" &&
               (element.source.abilityType.Contains("buff") || element.source.abilityType.Contains("buffStats"));
    }

    public static bool IsSpellAbilityHeal(this Element element)
    {
        if (element.source == null) return false;
        return element.source.group == "SPELL" && element.source.category == "ability" &&
               (element.source.abilityType.Contains("heal") || element.source.abilityType.Contains("hot"));
    }

    public static bool IsSpellAbilityCure(this Element element)
    {
        if (element.source == null) return false;
        return element.source.group == "SPELL" && element.source.category == "ability" &&
               (element.source.abilityType.Contains("heal") || element.source.abilityType.Contains("cure"));
    }
}
