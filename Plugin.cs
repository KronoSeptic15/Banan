using BepInEx;
using System;
using System.ComponentModel;
using System.Reflection;
using UnityEngine;
using Utilla;


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
			GameObject banan = bundle.LoadAsset<GameObject>("banana");
			var banana = Instantiate(banan);
			GameObject hand = GameObject.Find("OfflineVRRig/Actual Gorilla/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/palm.01.L");
			banana.transform.SetParent(hand.transform, false);
			banana.transform.localPosition = new Vector3(-0.016f, 0.159f, 0.05f);
			banana.transform.localScale = new Vector3(15f, 15f, 15f);
			banana.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
		}
		private void OnEnable() => Plugin.banana.SetActive(true);

		private void OnDisable() => Plugin.banana.SetActive(false);
	}
}
