using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JobSystem : MonoBehaviour, IJobSystem
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            SetJob(Hunter.CreateInstance());
        }
    }
    public void SetJob(Job jobToGive)
    {
        AttackSystem.ChangeAttack(AttackSystem.BaseAttack, jobToGive.JobBaseAttack);
        AttackSystem.ChangeAttack(AttackSystem.MeleeAttack, jobToGive.JobMeleeAttack);
        AttackSystem.ChangeAttack(AttackSystem.RangeAttack, jobToGive.JobRangeAttack);
        AttackSystem.ChangeAttack(AttackSystem.Ability, jobToGive.JobAbility);
    }

    public void ChangeJob()
    {
        throw new System.NotImplementedException();
    }
}
