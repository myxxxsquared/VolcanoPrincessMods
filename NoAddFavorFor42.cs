using HarmonyLib;

namespace VolcanoPrincessMods
{
    [HarmonyPatch(typeof(ItemSys), "AddShopFavor")]
    public class NoAddFavorFor42
    {
        [HarmonyPrefix]
        public static bool Prefix()
        {
            return !NpcSys.tempNpc.enName.Equals("42");
        }

    }
}
