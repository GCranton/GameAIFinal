using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : MonoBehaviour
{
    [SerializeField]
    private Generator[] generators;
    public GameObject enemyPrefab;
    public float spawnInterval = 20;

    private float curTime;

    void Start(){
        generators = gameObject.GetComponents<Generator>();
    }

    void Update(){
        curTime += Time.deltaTime;
        if(curTime >= spawnInterval){
            Instantiate(enemyPrefab, new Vector3(0,0,0), Quaternion.identity);
            curTime = 0;
        }
    }

    public Generator[] GetGenerators(){
        return generators;
    }
}
