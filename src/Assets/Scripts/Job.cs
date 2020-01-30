using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job : MonoBehaviour
{
    protected Attack AbilityToGive;
    public Attack JobBaseAttack { get; set; }
    protected Attack JobMeleeAttack;
    protected Attack JobRangeAttack;
}

class Hunter : Job
{
    public static Hunter CreateInstance()
    {
        Hunter hunterJob = new Hunter
        {
            AbilityToGive = Attack.CreateInstance(2,2,2,Attack.Effect.Slow,1,1),
            JobBaseAttack = Attack.CreateInstance(2,3,1,Attack.Effect.Slow,1,2),
            JobMeleeAttack = Attack.CreateInstance(1,1,2,Attack.Effect.None,1,2),
            JobRangeAttack = Attack.CreateInstance(3,4,8,Attack.Effect.Stun,1,1)
        };
        return hunterJob;
    }
}
