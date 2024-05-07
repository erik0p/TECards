using BepInEx;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnboundLib.Cards;
using UnityEngine;
using TECards.Cards;
using HarmonyLib;


namespace TECards
{
    [BepInDependency("com.willis.rounds.unbound")]
    [BepInDependency("pykess.rounds.plugins.moddingutils")]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch")]
    [BepInPlugin(ModId, ModName, Version)]
    [BepInProcess("Rounds.exe")]
    public class TECards : BaseUnityPlugin
    {
        private const string ModId = "com.thirdeye.tecards";
        private const string ModName = "TECards";
        private const string Version = "0.0.1";
        public const string ModInitials = "TE";
        internal static AssetBundle assets;

        private void Awake()
        {
            //assets = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("assets", typeof(TECards).Assembly);
            //assets.LoadAsset<GameObject>("ModCards").GetComponent<CardHolder>().RegisterCards();
            new Harmony(ModId).PatchAll();
        }

        // Start is called before the first frame update
        private void Start()
        {
            CustomCard.BuildCard<MozemDown>();
        }

        // Update is called once per frame
        private void Update()
        {

        }
    }
}
