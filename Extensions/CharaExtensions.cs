namespace ExperienceMultiplier.Extensions;

public static class CharaExtensions
{
    public static bool IsPCMinion(this Chara chara)
    {
        return chara.master != null && chara.master == EClass.pc;
    }
}