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
using BepInEx.Configuration;

namespace GorillaTagModTemplateProject
{
	/// <summary>
	/// This is your mod's main class.
	/// </summary>

	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	[Description("HauntedModMenu")]
	public class Plugin : BaseUnityPlugin
	{
		public static readonly string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		#pragma warning disable IDE0051 // IDE0051: Remove unused member
		void Start()
		{
			
		}

		void OnEnable()
		{
			/* Set up your mod here */
			/* Code here runs at the start and whenever your mod is enabled*/

			HarmonyPatches.ApplyHarmonyPatches();
			Utilla.Events.GameInitialized += OnGameInitialized;

		}

		void OnDisable()
		{
			/* Undo mod setup here */
			/* This provides support for toggling mods with ComputerInterface, please implement it :) */
			/* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

			HarmonyPatches.RemoveHarmonyPatches();
			Utilla.Events.GameInitialized -= OnGameInitialized;
		}

		void OnGameInitialized(object sender, EventArgs e)
		{
			/* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */
			Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("RocketMonke.Assets.banan");
			AssetBundle bundle = AssetBundle.LoadFromStream(str);
			GameObject banan = bundle.LoadAsset<GameObject>("banana");
			var banana = Instantiate(banan);
			GameObject hand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L");
			banana.transform.SetParent(hand.transform, false);
			banana.transform.localPosition = new Vector3(-0.016f, 0.159f, 0.05f);
			banana.transform.localScale = new Vector3(15f, 15f, 15f);
			banana.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
		}

		void Update()
		{
			/* Code here runs every frame when the mod is enabled */
		}

		/* This attribute tells Utilla to call this method when a modded room is joined */
	}
}