using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stub option for use in unimplemented features
public class DefaultOption : Option
{
    public override void Select(GameObject self, GameObject target){}
    public override bool Update(){return false;}
}