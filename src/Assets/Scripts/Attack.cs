using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Attack CreateAttack(int damage, int range, int cooldown, Effect effect, int level, int costToUpgrade)
    {
        Attack attack = new Attack();
        attack.Damage = damage;
        attack.Range = range;
        attack.Cooldown = cooldown;
        attack._effect = effect;
        attack.Level = level;
        attack.CostToUpgrade = costToUpgrade;
        return attack;
    }

    private int Damage;
    private int Range;
    private int Cooldown;
    private int Level;
    private int CostToUpgrade;
    private Effect _effect;

    public enum Effect
    {
        Slow,
        Stun,
        DoT,
        Leach,
        DmgReduction,
        None
    };
    
}
