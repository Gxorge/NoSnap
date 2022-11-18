using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;
using SG.Airlock;

namespace NoSnap;

[BepInPlugin("uk.hotten.nosnap", "NoSnap", "1.0")]
public class Plugin : BasePlugin
{
    public Harmony Harmony { get; } = new Harmony("uk.hotten.nosnap");

    public override void Load()
    {
        Harmony.PatchAll();

        Log.LogInfo($"NoSnap is ready!");
    }

    [HarmonyPatch(typeof(MinigameEngageZone), "EnterSnapZone")]
    public static class SnapPatch
    {
        public static void Prefix(MinigameEngageZone __instance)
        {
            __instance.UseMinigameSnap = false;
        }
    }
}
