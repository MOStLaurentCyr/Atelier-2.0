using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Job : ScriptableObject
{
    public Attack JobAbility { get; set; }
    public Attack JobBaseAttack { get; set; }
    public Attack JobMeleeAttack { get; set; }
    public Attack JobRangeAttack { get; set; }
}

class Hunter : Job
{
    public static Hunter CreateInstance()
    {
        Hunter hunterJob = ScriptableObject.CreateInstance<Hunter>();
        {
            hunterJob.JobBaseAttack = Attack.CreateInstance(2, 3, 1, Attack.Effect.Slow, 1, 2);
            hunterJob.JobMeleeAttack = Attack.CreateInstance(1, 1, 2, Attack.Effect.None, 1, 2);
            hunterJob.JobRangeAttack = Attack.CreateInstance(3, 4, 8, Attack.Effect.Stun, 1, 1);
            hunterJob.JobAbility = Attack.CreateInstance(2, 2, 2, Attack.Effect.Slow, 1, 1);
        };
        return hunterJob;
    }
}
