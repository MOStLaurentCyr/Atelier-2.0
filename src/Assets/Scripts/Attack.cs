using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    public static Attack CreateInstance(int damage, int range, int cooldown, Effect effect, int level, int costToUpgrade)
    {
        var attack = ScriptableObject.CreateInstance<Attack>();
        {
            attack.Damage = damage;
            attack.Range = range;
            attack.Cooldown = cooldown;
            attack._effect = effect;
            attack.Level = level;
            attack.CostToUpgrade = costToUpgrade;
        };
        return attack;
    }


    public int Damage;
    public int Range;
    public int Cooldown;
    public int Level;
    public int CostToUpgrade;
    public Effect _effect;

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
