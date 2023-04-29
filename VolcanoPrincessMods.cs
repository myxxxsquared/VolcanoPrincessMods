
using BepInEx;
using HarmonyLib;
using BepInEx.Logging;

namespace VolcanoPrincessMods
{
    [BepInPlugin("com.github.myxxxsquared.vpm", "VolcanoPrincessMods", "1.0.0")]
    public class VolcanoPrincessMods : BaseUnityPlugin
    {
        public void Awake()
        {
            ModLogger = BepInEx.Logging.Logger.CreateLogSource("VolcanoPrincessMods");
            ModLogger.LogInfo("I am running!");
            harmony = new Harmony("com.github.myxxxsquared.vpm");
            harmony.PatchAll();
            ModLogger.LogInfo("Harmony Patched!");
        }

        public static ManualLogSource ModLogger { get; private set; }
        private Harmony harmony;
    }

    [HarmonyPatch(typeof(NpcSys), "Load")]
    public class ClearFavorFor42
    {
        [HarmonyPostfix]
        public static void Postfix()
        {
            foreach (Person person in NpcSys.AllPerson("", -1))
            {
                if (person.enName.Equals("42") && person.favor > 100)
                {
                    person.AddFavor(-person.favor);
                }
            }
        }
    }    
}
