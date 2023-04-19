using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingGenerator : Generator
{
    public float chaseDistance;

    public override List<Option> generateOptions(GameObject self, GameObject target, float distance){
        List<Option> toReturn = new List<Option>();
        toReturn.Add(new FireOption());
        toReturn.Add(new ChaseOption(chaseDistance));
        toReturn.Add(new ReloadOption());
        return toReturn;
    }
}
