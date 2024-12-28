using ModdingUtils.MonoBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class SCP682Effect : MonoBehaviour
    {
        private Player player;
        public void Start()
        {
            player = gameObject.GetComponentInParent<Player>();

            player.data.stats.WasDealtDamageAction += OnDamage;
        }

        public void Destroy()
        {
            player.data.stats.WasDealtDamageAction -= OnDamage;
        }

        private void OnDamage(Vector2 damage, bool selfDamage)
        {
            if (selfDamage)
            {
                player.data.health += damage.magnitude;
            }
        }
    }
}
