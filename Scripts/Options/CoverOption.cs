using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Option for moving into a given cover point
public class CoverOption : Option
{
    private Transform position;
    private EnemyController control;

    public CoverOption(Transform pos){
        position = pos;
        tags = new List<OptionTag>{OptionTag.Position};
        // Disqualify this option if already in cover
        conditions = new List<Condition>{new OccupiedCondition(false, position, 5.0f), new ActualCoverCondition(true, position)};
        // Looks for the closest cover
        evaluators = new List<Evaluator>{new DistanceEvaluator(1, 10), new HealthEvaluator(10, false)};
    }

    public override void Select(GameObject self, GameObject target){
        control = self.GetComponent<EnemyController>();
        control.Move(position.position);
    }

    public override bool Update(){
        RaycastHit hit;
        if(Physics.Raycast(control.transform.position, control.transform.position - GameObject.FindWithTag("Player").transform.position, out hit, Mathf.Infinity)){
            return hit.transform.gameObject.tag != "Player";
        }
        return true;
    }
}
