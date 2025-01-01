using UnboundLib.Cards;
using UnityEngine;
using TECards.MonoBehaviours;

namespace TECards.Cards
{
    class SCP1853 : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            //cardInfo.allowMultiple = false;
            //gun.projectileColor = new Color(0.25f, 0.43f, 0.18f);
            gun.reloadTime = 0.85f;
            gun.attackSpeed = 0.85f;
            statModifiers.movementSpeed = 1.15f;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            SCP1853Effect effect = player.gameObject.AddComponent<SCP1853Effect>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetComponent<SCP1853Effect>());
        }

        protected override string GetTitle()
        {
            return "SCP-1853";
        }
        protected override string GetDescription()
        {
            return "Taking damage grants additional bonus stats. This effect may stack up to four times.";
        }
        protected override GameObject GetCardArt()
        {
            return TECards.SteroidsArt;
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
                    stat = "Movement Speed",
                    amount = "+15%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Attack Speed",
                    amount = "+15%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat()
                {
                    positive = true,
                    stat = "Reload Time",
                    amount = "-15%",
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.PoisonGreen;
        }
        public override string GetModName()
        {
            return (string)TECards.ModInitials;
        }
    }
}
