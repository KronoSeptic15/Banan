using System.Net;
using System.IO;
using System.Reflection;
using System.Collections.Generic;
using System;
using System.Text;
using System.Collections;
using System.ComponentModel;
using UnityEngine.XR;
using UnityEngine.UI;
using UnityEngine;
using Utilla;
using BepInEx;
using HarmonyLib;
using GorillaLocomotion;
using Photon.Pun;
using UnityEngine.Rendering;
using Bepinject;
using BepInEx.Configuration;
namespace GorillaTagModTemplate
{
    [Description("HauntedModMenu")]
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]

    [HarmonyPatch(typeof(GorillaLocomotion.Player))]
    [HarmonyPatch("Update", MethodType.Normal)]
    public class Plugin : BaseUnityPlugin
    {
        public bool inRoom;
        public static bool toggle;
        private NoClipManager modInstance = null;
        bool modEnabled = false;

        void OnEnable()
        {
            HarmonyPatches.ApplyHarmonyPatches();
            modEnabled = true;
            if (modInstance != null)
                modInstance.enabled = modEnabled && inRoom;
        }
        void OnDisable()
        {
            modEnabled = false;
            if (modInstance != null)
                modInstance.enabled = modEnabled;
            HarmonyPatches.RemoveHarmonyPatches();
        }
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            
            modInstance = gameObject.AddComponent<NoClipManager>();
            modInstance.enabled = modEnabled;
            inRoom = true;
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            GameObject.Destroy(modInstance);
            inRoom = false;

        }
    }
}