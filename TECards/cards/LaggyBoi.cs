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
    class LaggyBoi : CustomCard
    {
        private float damageToAdd;
        private float attackSpeedToAdd;
        private float ping;
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
        }
        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //int id;
            //foreach (int playerID in PingMonitor.instance.ConnectedPlayers.Keys)
            //{
            //    Player[] players = PingMonitor.instance.GetPlayersByOwnerActorNumber(playerID);
            //    for (int i = 0; i < players.Length; i++)
            //    {
            //        if (players[i].Equals(player))
            //        {
            //            UnityEngine.Debug.Log($"player is {players[i].data.name}");
            //            id = playerID;
            //            this.ping = PingMonitor.instance.PlayerPings[playerID];
            //            UnityEngine.Debug.Log($"ping is {ping}");
            //        }
            //    }
            //}
            //this.attackSpeedToAdd = gun.attackSpeed * ping / 100.0f;
            //this.damageToAdd = gun.damage * ping / 100.0f;
            //gun.attackSpeed += attackSpeedToAdd;
            //gun.damage += damageToAdd;
            //UnityEngine.Debug.Log($"damage is {gun.damage}");
            LaggyBoiEffect laggyBoiEffect = player.gameObject.AddComponent<LaggyBoiEffect>();
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
        }

        protected override string GetTitle()
        {
            return "Lag";
        }
        protected override string GetDescription()
        {
            return "Become stronger the laggier you are";
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
                    stat = "attackSpeed",
                    amount = ping.ToString(),
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
