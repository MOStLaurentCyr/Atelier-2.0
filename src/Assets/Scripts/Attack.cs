﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public static Attack CreateInstance(int damage, int range, int cooldown, Effect effect, int level, int costToUpgrade)
    {
        var attack = new Attack
        {
            Damage = damage,
            Range = range,
            Cooldown = cooldown,
            _effect = effect,
            Level = level,
            CostToUpgrade = costToUpgrade
        };
        return attack;
    }


    public int Damage;
    public int Range;
    public int Cooldown;
    public int Level;
    public int CostToUpgrade;
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
