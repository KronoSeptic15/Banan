using System.IO;
using System.Reflection;
using System;
using UnityEngine;
using Utilla;
using BepInEx;

namespace GorillaTagModTemplateProject
{
	/// <summary>
	/// This is your mod's main class.
	/// </summary>

	/* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
	[ModdedGamemode]
	[BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.0")]
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		//public static readonly string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
#pragma warning disable IDE0051 // IDE0051: Remove unused member
		void Start() 
		{ 
			Utilla.Events.GameInitialized += OnGameInitialized;
		}
		void OnGameInitialized(object sender, EventArgs e)
		{
			/* Code here runs after the game initializes (i.e. GorillaLocomotion.Player.Instance != null) */

			Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("Banan.Assets.banan");
			AssetBundle bundle = AssetBundle.LoadFromStream(str);
			GameObject banan = bundle.LoadAsset<GameObject>("banana");
			var banana = Instantiate(banan);
			GameObject hand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L");
			banana.transform.SetParent(hand.transform, false);
			banana.transform.localPosition = new Vector3(-0.016f, 0.159f, 0.05f);
			banana.transform.localScale = new Vector3(15f, 15f, 15f);
			banana.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
		}
	}
}