using BepInEx;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnboundLib.Cards;
using UnityEngine;
using TECards.Cards;
using HarmonyLib;
using Jotunn.Utils;


namespace TECards
{
    [BepInDependency("com.willis.rounds.unbound")]
    [BepInDependency("pykess.rounds.plugins.moddingutils")]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch")]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class TECards : BaseUnityPlugin
    {
        internal static AssetBundle assets;
        public static GameObject PolyphemusArt;
        public static GameObject SteroidsArt;

        private const string ModId = "com.thirdeye.tecards";
        private const string ModName = "TECards";
        private const string Version = "0.0.1";
        public const string ModInitials = "TE";


        private void Awake()
        {
            new Harmony(ModId).PatchAll();
        }

        // Start is called before the first frame update
        private void Start()
        {
            assets = AssetUtils.LoadAssetBundleFromResources("assets", typeof(TECards).Assembly);
            PolyphemusArt = assets.LoadAsset<GameObject>("C_Polyphemus");
            SteroidsArt = assets.LoadAsset<GameObject>("C_Steroids");

            //CustomCard.BuildCard<MozemDown>(); // Card not finished
            CustomCard.BuildCard<LaggyBoi>();
            CustomCard.BuildCard<Polyphemus>();
            CustomCard.BuildCard<Steroids>();
            CustomCard.BuildCard<AntiCola>();
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
