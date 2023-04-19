using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHealthEvaluator : Evaluator {
    private bool high;

    public TargetHealthEvaluator(float w, bool wantHigh) : base(w) {
        high = wantHigh;
    }

    // Ranks a specific utility 0-1 * weight
    public override float Evaluate(GameObject self, GameObject target) {
        EntityStats targetStats = target.GetComponent<EntityStats>();
        if(high){
            return (targetStats.health / targetStats.maxHealth) * weight;
        } else {
            return ((targetStats.maxHealth - targetStats.health) / targetStats.maxHealth) * weight;
        }
    }
}