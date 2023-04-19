using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finds options for the AI to choose from
public abstract class Generator : MonoBehaviour
{
    // Each generator gets the enemy itself, whatever target (usually the player) the enemy is fighting, 
    // and a distance value that is usually (but not necessarily always) the radius within which to find options
    public abstract List<Option> generateOptions(GameObject self, GameObject target, float distance);
}
