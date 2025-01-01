using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;

namespace TECards.Cards
{
    class LaggyBoi : CustomCard
    {
        private float damageToAdd;
        private float attackSpeedToAdd;
        private int ping;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            int id;
            foreach (int playerID in PingMonitor.instance.ConnectedPlayers.Keys)
            {
                Player[] players = PingMonitor.instance.GetPlayersByOwnerActorNumber(playerID);
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].Equals(player))
                    {
                        UnityEngine.Debug.Log($"playerid is {playerID}");
                        id = playerID;
                        this.ping = PingMonitor.instance.PlayerPings[playerID];
                        UnityEngine.Debug.Log($"ping is {ping}");
                        this.ping = 88;
                    }
                }
            }
            this.attackSpeedToAdd = gun.attackSpeed * ping * 0.01f * 0.333f;
            this.damageToAdd = gun.damage * ping * 0.01f * 0.333f;
            UnityEngine.Debug.Log($"attackspd{attackSpeedToAdd}, dmg{damageToAdd}");
            gun.attackSpeed -= attackSpeedToAdd;
            gun.damage += damageToAdd;
            UnityEngine.Debug.Log($"damage is {gun.damage}");
            UnityEngine.Debug.Log($"atkspd is {gun.attackSpeed}");
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            gun.attackSpeed += attackSpeedToAdd;
            gun.damage -= damageToAdd;
        }

        protected override string GetTitle()
        {
            return "LaggyBoi";
        }
        protected override string GetDescription()
        {
            return "Gain power based on ping";
        }
        protected override GameObject GetCardArt()
        {
            return null;
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
                    stat = "damage",
                    amount = ping.ToString(),
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                },
                new CardInfoStat() 
                {
                    positive = true,
                    stat = "attackSpeed",
                    amount = ping.ToString(),
                    simepleAmount = CardInfoStat.SimpleAmount.notAssigned
                }

            };
        }
        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DefensiveBlue;
        }
        public override string GetModName()
        {
            return (string)TECards.ModInitials;
        }
    }
}
