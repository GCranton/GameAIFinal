using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOption : Option
{    
    private Gun gunScript;
    private GameObject shootAt;
    private EnemyController control;

    public FireOption(){
        tags = new List<OptionTag> {OptionTag.Action};
        // Fire only if: has ammo, in range to actually hit
        conditions = new List<Condition>{new HasAmmoCondition(true), new InRangeCondition(true)};
        evaluators = new List<Evaluator>{new EnoughAmmoEvaluator(1, true)};
    }

    public override void Select(GameObject self, GameObject target){
        control = self.GetComponent<EnemyController>();
        control.Look(target.transform);
        gunScript = self.transform.GetChild(0).gameObject.GetComponent<Gun>();
        shootAt =  target;
    }

    // Keeps shooting until it misses the player or moves out of range
    public override bool Update(){
        return gunScript.Shoot();
    }
}
