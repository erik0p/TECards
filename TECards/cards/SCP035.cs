using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using TECards.MonoBehaviours;
using TECards.RoundsEffects;
using UnboundLib.GameModes;

namespace TECards.Cards
{
    class SCP035 : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            cardInfo.allowMultiple = false;
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            SCP035Effect reversibleEffect = player.gameObject.AddComponent<SCP035Effect>();
            SCP035WasDealtDamageEffect wasDealtDamageEffect = player.gameObject.GetOrAddComponent<SCP035WasDealtDamageEffect>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            Destroy(player.gameObject.GetComponent<SCP035Effect>());
        }

        protected override string GetTitle()
        {
            return "SCP-035";
        }
        protected override string GetDescription()
        {
            return "Alternates between two powerful buffs. This card's power is temporarily transferred to players who kill someone in possesion of SCP-035.";
        }
        protected override GameObject GetCardArt()
        {
            return TECards.SCP035Art;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.EvilPurple;
        }
        public override string GetModName()
        {
            return (string)TECards.ModInitials;
        }
    }
}
