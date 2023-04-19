using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InRangeCondition : Condition {
    // 'positive' is whether or not you want the condition to be true
    public InRangeCondition(bool pos) : base(pos){}

    // True if the enemy currently has ammo
    public override bool Check(GameObject enemy, GameObject target) {
        return (Vector3.Distance(enemy.transform.position, target.transform.position) <= enemy.transform.GetChild(0).GetComponent<Gun>().maxRange) == positive;
    }
}