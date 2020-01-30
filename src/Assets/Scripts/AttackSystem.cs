﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour,IAttackSystem
{
    public static Attack BaseAttack;

    public static Attack MeleeAttack;

    public static Attack RangeAttack;

    public static Attack Ability;

    // Start is called before the first frame update
    void Start()
    {
        BaseAttack = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
        MeleeAttack = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
        RangeAttack = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
        Ability = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DoAttack(BaseAttack);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UpgradeAttack(BaseAttack);
        }
    }

    public void DoAttack(Attack attackToDo)
    {
        Debug.Log("Bang!");
    }

    public static void ChangeAttack(Attack attackToChange, Attack newAttack)
    {
        attackToChange = newAttack;
        Debug.Log(attackToChange.Damage.ToString());
    }

    public void UpgradeAttack(Attack attackToUpgrade)
    {
        attackToUpgrade.Level++;
        Debug.Log("Attack been upgrade to level : " + attackToUpgrade.Level.ToString());
    }

    void IAttackSystem.ChangeAttack(Attack attackToChange, Attack newAttack)
    {
        ChangeAttack(attackToChange, newAttack);
    }
}
