using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum OptionTag {
    Position,
    Action
}

public abstract class Option
{
    public List<OptionTag> tags;
    public List<Condition> conditions;
    public List<Evaluator> evaluators;

    private float utility = 0;

    // Do the thing this option is made for
    // Give it the enemy itself, and a potential target object
    public abstract void Select(GameObject self, GameObject target);

    // Returns true as long as the Option is relevant
    public abstract bool Update();

    public List<Condition> GetConditions() {
        return conditions;
    }

    public List<Evaluator> GetEvaluators() {
        return evaluators;
    }

    public float GetUtility(){
        return utility;
    }

    public void SetUtility(float u){
        // TODO: Input validation making sure it's between 0 and 1?
        utility = u;
    }
}
