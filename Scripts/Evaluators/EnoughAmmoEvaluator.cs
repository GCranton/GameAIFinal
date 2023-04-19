using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnoughAmmoEvaluator : Evaluator {
    private bool high;
    public EnoughAmmoEvaluator(float w, bool wantHigh) : base(w){
        high = wantHigh;
    }
    
    // Value is just the proportion of maxAmmo we have left
    public override float Evaluate(GameObject self, GameObject target) {
        Gun gun = self.transform.GetChild(0).GetComponent<Gun>();
        if(high){
            return (gun.GetAmmo() / gun.maxAmmo) * weight;
        } else {
            return ((gun.maxAmmo - gun.GetAmmo()) / gun.maxAmmo) * weight;
        }
    }
}