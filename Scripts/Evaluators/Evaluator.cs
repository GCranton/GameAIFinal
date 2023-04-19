using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Evaluator {
    // How important this factor is in the decision
    protected float weight;

    public Evaluator(float w){
        weight = w;
    }

    public float GetWeight(){
        return weight;
    }

    // Ranks a specific utility 0-1 * weight
    public abstract float Evaluate(GameObject self, GameObject target);
}