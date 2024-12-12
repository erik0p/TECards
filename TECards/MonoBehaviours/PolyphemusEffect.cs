using HarmonyLib;
using ModdingUtils.Extensions;
using ModdingUtils.MonoBehaviours;
using UnboundLib;
using UnityEngine;

namespace TECards.MonoBehaviours
{
    public class PolyphemusEffect : MonoBehaviour
    {
        private Player playerToModify;
        private Gun gunToModify;
        private int totalAmmoCount;
        private int currentAmmoCount;
        private float projectileSize;
        void Awake()
        {

        }

        void Start()
        {
            this.playerToModify = gameObject.GetComponent<Player>();
            this.gunToModify = playerToModify.GetComponent<Holding>().holdable.GetComponent<Gun>();
            this.totalAmmoCount =  gunToModify.GetComponentInChildren<GunAmmo>().maxAmmo;
            this.currentAmmoCount = totalAmmoCount;
            this.projectileSize = gunToModify.projectileSize;
        }

        void Update()
        {
            GunAmmo currentAmmo = gunToModify.GetComponentInChildren<GunAmmo>();
            float increaseSizeAmount = 0f;
            totalAmmoCount = currentAmmo.maxAmmo;
            currentAmmoCount = (int)currentAmmo.GetFieldValue("currentAmmo");

            if (currentAmmoCount > 0)
            {
                increaseSizeAmount = UnityEngine.Mathf.Lerp(10f, 0f, ((float)currentAmmoCount / (float)totalAmmoCount));
                if (totalAmmoCount == 1)
                {
                    increaseSizeAmount = 10f;
                }
            }
            gunToModify.projectileSize = increaseSizeAmount;
        }

        public void OnDestroy()
        {

        }

        public void Destroy()
        {
            UnityEngine.Object.Destroy(this);
        }
    }
}
