using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OccupiedCondition : Condition {
    private Transform targetLocation;
    private float distance;
    public OccupiedCondition(bool pos, Transform location, float dist) : base(pos) {
        targetLocation = location;
        distance = dist;
    }

    // Checks whether or not the enemy is hidden from the target
    public override bool Check(GameObject enemy, GameObject target) {
        foreach(GameObject other in GameObject.FindGameObjectsWithTag("Enemy")){
            if (other != enemy){
                if(Vector3.Distance(other.transform.position, targetLocation.position) <= distance){
                    return true == positive;
                }
            }
        }
        return false == positive;
    }
}