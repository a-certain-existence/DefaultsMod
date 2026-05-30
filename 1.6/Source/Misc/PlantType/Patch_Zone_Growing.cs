using HarmonyLib;
using RimWorld;
using Verse;

namespace Defaults.Misc.PlantType
{
    [HarmonyPatchCategory("Misc")]
    [HarmonyPatch(typeof(Zone_Growing))]
    [HarmonyPatch(nameof(Zone_Growing.PlantDefToGrow), MethodType.Getter)]
    public static class Patch_Zone_Growing_get_PlantDefToGrow
    {
        public static void Prefix(Zone_Growing __instance, ref ThingDef ___plantDefToGrow)
        {
            // Check type to avoid patching non-vanilla grow zones
            if (__instance.GetType() == typeof(Zone_Growing) && ___plantDefToGrow == null)
            {
                ___plantDefToGrow = PollutionUtility.SettableEntirelyPolluted(__instance)
                    ? ThingDefOf.Plant_Toxipotato
                    : Settings.Get<ThingDef>(Settings.PLANT_TYPE);
            }
        }
    }
}
