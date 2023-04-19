using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActualCoverCondition : Condition {
    private Transform targetPos;

    public ActualCoverCondition(bool pos, Transform position) : base(pos) {
        targetPos = position;
    }

    // Checks whether or not the enemy is hidden from the target
    public override bool Check(GameObject enemy, GameObject target) {
        RaycastHit hit;
        return Physics.Raycast(target.transform.position, targetPos.position - target.transform.position, out hit, Vector3.Distance(targetPos.position, target.transform.position)) == positive;
    }
}