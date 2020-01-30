using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour,IAttackSystem
{
    public Attack baseAttack;

    public Attack meleeAttack;

    public Attack rangeAttack;

    public Attack ability;

    // Start is called before the first frame update
    void Start()
    {
        baseAttack = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
        meleeAttack = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
        rangeAttack = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
        ability = Attack.CreateInstance(1, 1, 1, Attack.Effect.None, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            DoAttack(baseAttack);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            UpgradeAttack(baseAttack);
        }
    }

    public void DoAttack(Attack attackToDo)
    {
        Debug.Log("Bang!");
    }

    public void UpgradeAttack(Attack attackToUpgrade)
    {
        attackToUpgrade.Level++;
        Debug.Log("Attack been upgrade to level : " + attackToUpgrade.Level.ToString());
    }
}
