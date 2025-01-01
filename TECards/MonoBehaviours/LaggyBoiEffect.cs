using ModdingUtils.MonoBehaviours;
using UnboundLib;

namespace TECards.MonoBehaviours
{
    public class LaggyBoiEffect : ReversibleEffect
    {
        private Gun gunToModify;
        private int ping;
        private int id;

        public override void OnAwake()
        {
            base.OnAwake();
            foreach (int playerID in PingMonitor.instance.ConnectedPlayers.Keys)
            {
                Player[] players = PingMonitor.instance.GetPlayersByOwnerActorNumber(playerID);
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].Equals(this.player))
                    {
                        UnityEngine.Debug.Log($"player is {players[i].data.name}");
                        this.id = playerID;
                        this.ping = PingMonitor.instance.PlayerPings[playerID];
                    }
                }
            }
            UnityEngine.Debug.Log($"ping is {ping}");
            this.gunStatModifier.damage_mult *= 0.5f;
            UnityEngine.Debug.Log($"damage is {gun.damage}");
        }
        public override void OnStart()
        {
            base.OnStart();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();
        }
    }
}
