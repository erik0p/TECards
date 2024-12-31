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
    class GreenCandy : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            block.cdMultiplier = 1.1f;
            statModifiers.health = 1.2f;
            cardInfo.categories = new CardCategory[] { TECards.Candy };
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            GreenCandyEffect effect = player.gameObject.AddComponent<GreenCandyEffect>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetComponent<GreenCandyEffect>());
        }

        protected override string GetTitle()
        {
            return "Green Candy";
        }
        protected override string GetDescription()
        {
            return "Grants health regeneration while your block is on cooldown.";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Regen",
                    amount = "+4hp/s",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Health",
                    amount = "+20%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = false,
                    stat = "Block Cooldown",
                    amount = "+10%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }

        public override string GetModName()
        {
            return (string)TECards.ModInitials;
        }
    }
}
