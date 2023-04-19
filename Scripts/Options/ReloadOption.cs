using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadOption : Option
{
    private Gun gunScript;

    public ReloadOption(){
        tags = new List<OptionTag>{OptionTag.Action};
        conditions = new List<Condition>{};
        evaluators = new List<Evaluator>{new EnoughAmmoEvaluator(1, false)};
    }
    public override void Select(GameObject self, GameObject target){
        gunScript = self.transform.GetChild(0).gameObject.GetComponent<Gun>();
        // Debug.Log("Reloading!");
        gunScript.Reload();
    }
    public override bool Update(){
        return gunScript.GetAmmo() == gunScript.maxAmmo;
    }
}