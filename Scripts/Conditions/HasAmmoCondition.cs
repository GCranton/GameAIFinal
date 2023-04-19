using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasAmmoCondition : Condition {
    // 'positive' is whether or not you want the condition to be true
    public HasAmmoCondition(bool pos) : base(pos){}

    // True if the enemy currently has ammo
    public override bool Check(GameObject enemy, GameObject target) {
        return (enemy.transform.GetChild(0).GetComponent<Gun>().GetAmmo() > 0) == positive;
    }
}