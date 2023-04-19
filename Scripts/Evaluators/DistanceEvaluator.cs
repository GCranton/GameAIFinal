using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEvaluator : Evaluator {
    // Used to adjust how steep the utility curve is
    private float m_coefficient = 0.5f;
    private float optimumDistance;
    private Vector3 optionalPosition;

    public DistanceEvaluator(float w, float dist) : base(w){
        optimumDistance = dist;
    }

    public DistanceEvaluator(float w, float dist, Vector3 pos) : base(w){
        optimumDistance = dist;
        optionalPosition = pos;
    }
    
    // If optionalPosition has been set, rates the distance to that. Otherwise rates the distance to target
    // Value is a rating of how close the distance is to optimumDistance
    // Set optimumDistance to 0 for rating close things higher, or to some arbitrarily high number for rating close things lower.
    public override float Evaluate(GameObject self, GameObject target) {
        float currentDistance;
        if(optionalPosition == null){
            currentDistance = Vector3.Distance(self.transform.position, target.transform.position);
        } else {
            currentDistance = Vector3.Distance(self.transform.position, optionalPosition);
        }
        float diff = Mathf.Abs(optimumDistance - currentDistance);
        // As diff increases, this function approaches 0. It returns 0.5 when the difference is exactly optimumDistance * c
        return (m_coefficient * optimumDistance/(diff + m_coefficient * optimumDistance)) * weight; 
    }
}