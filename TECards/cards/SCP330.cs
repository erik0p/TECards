using UnboundLib.Cards;
using UnityEngine;

namespace TECards.Cards
{
    class SCP330 : CustomCard
    {

        public static CardCategory[] CandyCategory = new CardCategory[] { CardChoiceSpawnUniqueCardPatch.CustomCategories.CustomCardCategories.instance.CardCategory("Candy") };
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            CardInfo candyCard1 = GetCandyCard();
            ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, candyCard1, addToCardBar: true);
            ModdingUtils.Utils.CardBarUtils.instance.ShowAtEndOfPhase(player, candyCard1);

            CardInfo candyCard2 = GetCandyCard();
            ModdingUtils.Utils.Cards.instance.AddCardToPlayer(player, candyCard2, addToCardBar: true);
            ModdingUtils.Utils.CardBarUtils.instance.ShowAtEndOfPhase(player, candyCard2);
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }

        protected override string GetTitle()
        {
            return "SCP-330";
        }
        protected override string GetDescription()
        {
            return "Get two random candies.";
        }
        protected override GameObject GetCardArt()
        {
            return TECards.SCP330Art;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Uncommon;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.TechWhite;
        }

        public override string GetModName()
        {
            return (string)TECards.ModInitials;
        }

        public static CardInfo GetCandyCard()
        {
            int randnum = UnityEngine.Random.Range(0, 5);
            switch (randnum)
            {
                case 0:
                    return ModdingUtils.Utils.Cards.instance.GetCardWithName("Blue Candy");
                case 1:
                    return ModdingUtils.Utils.Cards.instance.GetCardWithName("Yellow Candy");
                case 2:
                    return ModdingUtils.Utils.Cards.instance.GetCardWithName("Green Candy");
                case 3:
                    return ModdingUtils.Utils.Cards.instance.GetCardWithName("Rainbow Candy");
                case 4:
                    return ModdingUtils.Utils.Cards.instance.GetCardWithName("Red Candy");
                default:
                    return null;

            }
        }
    }
}
