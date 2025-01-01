using TECards.MonoBehaviours;
using UnboundLib.Cards;
using UnityEngine;

namespace TECards.Cards
{
    class RedCandy : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            statModifiers.regen = 3f;
            statModifiers.health = 1.3f;
            cardInfo.categories = new CardCategory[] { TECards.Candy };
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            RedCandyEffect effect = player.gameObject.AddComponent<RedCandyEffect>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetComponent<RedCandyEffect>());
        }

        protected override string GetTitle()
        {
            return "Red Candy";
        }
        protected override string GetDescription()
        {
            return "Grants health regeneration for the first 30 seconds of each round.";
        }
        protected override GameObject GetCardArt()
        {
            return TECards.RedCandyArt;
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
                    stat = "Life Regen",
                    amount = "+10",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Health",
                    amount = "+30%",
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
