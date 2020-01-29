using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSystem : MonoBehaviour,IAttackSystem
{
    private Attack baseAttack;

    private Attack meleeAttack;

    private Attack rangeAttack;

    private Attack ability;
    // Start is called before the first frame update
    void Start()
    {
        baseAttack.CreateAttack(1, 1, 1, Attack.Effect.None, 1, 1);
        meleeAttack.CreateAttack(1, 1, 1, Attack.Effect.None, 1, 1);
        rangeAttack.CreateAttack(1, 1, 1, Attack.Effect.None, 1, 1);
        ability.CreateAttack(1, 1, 1, Attack.Effect.None, 1, 1);
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
        Debug.Log("Attack Upgraded!");
    }
}
