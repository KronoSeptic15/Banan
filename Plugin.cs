
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
	[BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
	public class Plugin : BaseUnityPlugin
	{
		public static readonly string assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		#pragma warning disable IDE0051 // IDE0051: Remove unused member
		void OnGameInitialized(object sender, EventArgs e)
		{
			Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("Banan.Assets.banan");
			AssetBundle bundle = AssetBundle.LoadFromStream(str);
			if (bundle)
			{
				Debug.Log("bundle = true");
			}
			GameObject banan = bundle.LoadAsset<GameObject>("banana");
			if (banan)
			{
				Debug.Log("banan = true");
			}
			var banana = Instantiate(banan);
			if (banana)
			{
				Debug.Log("banana = true");
			}
			GameObject hand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L");
			if (hand)
			{
				Debug.Log("hand = true");
			}
			banana.transform.SetParent(hand.transform, false);
			banana.transform.localPosition = new Vector3(-0.016f, 0.159f, 0.05f);
			banana.transform.localScale = new Vector3(15f, 15f, 15f);
			banana.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
		}
	}
}