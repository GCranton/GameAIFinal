using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoverPositionGenerator : Generator
{
    [SerializeField]
    private GameObject[] coverPositions;

    void Start(){
        coverPositions = GameObject.FindGameObjectsWithTag("Cover");
    }

    // Necessary arguments:
    // 1 objArg (the enemy character)
    // 1 numArg (the radius within which to find cover points)
    public override List<Option> generateOptions(GameObject self, GameObject target, float distance){
        List<Option> toReturn = new List<Option>();
        foreach(GameObject pos in coverPositions){
            if(Vector3.Distance(pos.transform.position, self.transform.position) <= distance){
                toReturn.Add(new CoverOption(pos.transform));
            }
        }
        return toReturn;
    }
}
