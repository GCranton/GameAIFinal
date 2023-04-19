using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthEvaluator : Evaluator {
    private bool high;

    public HealthEvaluator(float w, bool wantHigh) : base(w) {
        high = wantHigh;
    }

    // Ranks a specific utility 0-1 * weight
    public override float Evaluate(GameObject self, GameObject target) {
        EntityStats selfStats = self.GetComponent<EntityStats>();
        if(high){
            return (selfStats.health / selfStats.maxHealth) * weight;
        } else {
            return ((selfStats.maxHealth - selfStats.health) / selfStats.maxHealth) * weight;
        }
    }
}