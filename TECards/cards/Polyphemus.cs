using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TECards.MonoBehaviours;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace TECards.Cards
{
    class Polyphemus : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
            gun.reloadTimeAdd = 0.25f;
            gun.damage = 1.5f;
            gun.attackSpeed = 1.5f;
            gun.projectielSimulatonSpeed = 0.5f;
            //UnityEngine.Debug.Log($"[{TECards.ModInitials}][Card] {GetTitle()} has been setup.");
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            PolyphemusEffect polyphemusEffect = player.gameObject.AddComponent<PolyphemusEffect>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.transform.gameObject.GetComponent<PolyphemusEffect>());
        }

        protected override string GetTitle()
        {
            return "Polyphemus";
        }
        protected override string GetDescription()
        {
            return "Bullet size increases the less ammo you have remaining";
        }
        protected override GameObject GetCardArt()
        {
            return TECards.PolyphemusArt;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Damage",
                    amount = "+50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Reload Time",
                    amount = "+0.25s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Projectile Speed",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Attack Speed",
                    amount = "-50%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return (string)TECards.ModInitials;
        }
    }
}
