using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionChooser {
    public static List<Option> PruneOptions(List<Option> oldList, GameObject self, GameObject target){
        List<Option> newList = new List<Option>();
        foreach(Option o in oldList){
            bool add = true;
            foreach(Condition c in o.GetConditions()){
                if(!c.Check(self, target)){
                    add = false;
                }
            }
            if(add){
                newList.Add(o);
            }
        }
        return newList;
    }

    // returns the average utility of the Option
    // always between 0 and 1
    public static float RateOption(Option o, GameObject self, GameObject target){
        float totalWeight = 0;
        float totalUtil = 0;
        foreach(Evaluator e in o.GetEvaluators()){
            totalWeight += e.GetWeight();
            totalUtil += e.Evaluate(self, target);
        }
        return totalUtil / totalWeight;
    }

    // Comparison<T> implementation for List.Sort
    // Ought to make it so the largest utility options are earliest in the list
    public static int CompareOptionsByUtility(Option x, Option y){
        float xUtil = x.GetUtility();
        float yUtil = y.GetUtility();
        if(xUtil == yUtil){
            return 0;
        } else if(xUtil > yUtil){
            return -1;
        } else {
            return 1;
        }
    }
}