using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackSystem
{
    void DoAttack(Attack attackToDo);
    void UpgradeAttack(Attack attackToUpgrade);
}
