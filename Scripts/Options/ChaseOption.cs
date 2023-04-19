using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Option for chasing a given target
public class ChaseOption : Option
{
    private EnemyController control;
    private GameObject quarry;
    private float distance;

    public ChaseOption(float desiredDistance){
        tags = new List<OptionTag>{OptionTag.Position};
        conditions = new List<Condition>{};
        evaluators = new List<Evaluator>{new HealthEvaluator(1, true), new TargetHealthEvaluator(2, false)};
        
        distance = desiredDistance;
    }

    public override void Select(GameObject self, GameObject target){
        control = self.GetComponent<EnemyController>();
        quarry = target;
        control.Move(quarry.transform.position);
    }

    public override bool Update(){
        if(Vector3.Distance(quarry.transform.position, control.transform.position) <= distance){
            control.Move(control.transform.position);
        }
        else {
            control.Move(quarry.transform.position);
        }
        return true;
    }
}
