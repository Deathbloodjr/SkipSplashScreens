using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipSplashScreens.Patches
{
    internal class SkipSplashScreensPatch
    {
        [HarmonyPatch(typeof(BootManager))]
        [HarmonyPatch(nameof(BootManager.changeState))]
        [HarmonyPostfix]
        private static void BootManager_changeState_Postfix(BootManager __instance)
        {
            __instance.m_fadeInSpeed = 1;
            __instance.m_fadeInSpeed = 1;
        }

        [HarmonyPatch(typeof(BootManager))]
        [HarmonyPatch(nameof(BootManager.updateSetFullScreen))]
        [HarmonyPrefix]
        private static void BootManager_updateSetFullScreen_Prefix(BootManager __instance)
        {
            __instance.changeState(BootManager.BootState.Logo, BootManager.BootState.Init);
        }

        [HarmonyPatch(typeof(BootManager))]
        [HarmonyPatch(nameof(BootManager.updateLogo))]
        [HarmonyPrefix]
        private static void BootManager_updateLogo_Prefix(BootManager __instance)
        {
            __instance.m_bSkip = true;
            __instance.changeState(BootManager.BootState.LogoCRI, BootManager.BootState.Logo);
        }

        [HarmonyPatch(typeof(BootManager))]
        [HarmonyPatch(nameof(BootManager.updateLogoCRI))]
        [HarmonyPrefix]
        private static void BootManager_updateLogoCRI_Prefix(BootManager __instance)
        {
            __instance.m_bSkip = true;
            __instance.changeState(BootManager.BootState.AutoSaveHeadsUp, BootManager.BootState.LogoCRI);
        }

        [HarmonyPatch(typeof(BootManager))]
        [HarmonyPatch(nameof(BootManager.updateAutoSaveHeadsUp))]
        [HarmonyPrefix]
        private static void BootManager_updateAutoSaveHeadsUp_Prefix(BootManager __instance)
        {
            __instance.m_bSkip = true;
            __instance.changeState(BootManager.BootState.End, BootManager.BootState.AutoSaveHeadsUp);
        }
    }
}
