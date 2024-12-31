using BepInEx;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnboundLib.Cards;
using UnityEngine;
using TECards.Cards;
using HarmonyLib;
using Jotunn.Utils;
using UnityEditor;
using UnboundLib.GameModes;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


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
        public static GameObject AntiColaArt;
        public static GameObject SCP035Art;
        public static GameObject SCP207Art;

        private const string ModId = "com.thirdeye.tecards";
        private const string ModName = "TECards";
        private const string Version = "0.0.1";
        public const string ModInitials = "TE";
        public static CardCategory Candy;


        private void Awake()
        {
            new Harmony(ModId).PatchAll();
        }

        private void Start()
        {
            assets = AssetUtils.LoadAssetBundleFromResources("assets", typeof(TECards).Assembly);
            PolyphemusArt = assets.LoadAsset<GameObject>("C_Polyphemus");
            SteroidsArt = assets.LoadAsset<GameObject>("C_Steroids");
            AntiColaArt = assets.LoadAsset<GameObject>("C_Anti-Cola");
            SCP035Art = assets.LoadAsset<GameObject>("C_SCP035");
            SCP207Art = assets.LoadAsset<GameObject>("C_SCP207");

            Candy = CustomCardCategories.instance.CardCategory("Candy");

            //CustomCard.BuildCard<LaggyBoi>(); // Card not finished
            CustomCard.BuildCard<MozemDown>();
            CustomCard.BuildCard<Polyphemus>();
            CustomCard.BuildCard<SCP1853>();
            CustomCard.BuildCard<AntiCola>();
            CustomCard.BuildCard<SCP035>();
            CustomCard.BuildCard<SCP682>();
            CustomCard.BuildCard<SCP999>();
            CustomCard.BuildCard<SCP207>();
            CustomCard.BuildCard<BlueCandy>();
            CustomCard.BuildCard<GreenCandy>();
            CustomCard.BuildCard<RedCandy>();
            CustomCard.BuildCard<YellowCandy>();
            CustomCard.BuildCard<RainbowCandy>();
            CustomCard.BuildCard<SCP330>();

            GameModeManager.AddHook(GameModeHooks.HookGameStart, GameStart);

            IEnumerator GameStart(IGameModeHandler gameModeHandler)
            {
                foreach (var player in PlayerManager.instance.players)
                {
                    if (!ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).blacklistedCategories.Contains(TECards.Candy))
                    {
                         ModdingUtils.Extensions.CharacterStatModifiersExtension.GetAdditionalData(player.data.stats).blacklistedCategories.Add(TECards.Candy);
                        
                    }
                }
                yield break;
            }
        }
    }
}
