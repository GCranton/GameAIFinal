using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Condition {
    protected bool positive;

    // 'positive' is whether or not you want the condition to be true
    public Condition(bool pos) {
        positive = pos;
    }

    // Checks whether or not the enemy meets certain criteria
    public abstract bool Check(GameObject self, GameObject target);
}