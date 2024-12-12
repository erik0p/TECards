using ModdingUtils.MonoBehaviours;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCP1853Effect : ReversibleEffect
{
    private int stacks = 0;
    //public static Color green = new Color(0.25f, 0.43f, 0.18f);

    public override void OnStart()
    {
        base.OnStart();
        player.data.stats.WasDealtDamageAction += OnDamage;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        ApplyModifiers();
    }

    public override void OnOnDestroy()
    {
        base.OnOnDestroy();
        player.data.stats.WasDealtDamageAction -= OnDamage;
    }

    private void OnDamage(Vector2 damage, bool selfDamage)
    {
        if (!selfDamage && stacks < 4)
        {
            stacks++;
            ClearModifiers();
            this.gunStatModifier.attackSpeed_mult = 1f - (stacks * 0.15f); 
            this.gunAmmoStatModifier.reloadTimeMultiplier_mult = 1f - (stacks * 0.15f);
            this.characterStatModifiersModifier.movementSpeed_mult = 1f + (stacks * 0.15f);
            this.gunStatModifier.projectileColor = Color.Lerp(this.gun.projectileColor, Color.red, (float)stacks / 4.0f);
        }
    }
}
