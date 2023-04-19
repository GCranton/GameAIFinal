using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public EntityStats stats;

    private UnityEngine.AI.NavMeshAgent agent;

    // Handling moving and looking separately allows the enemy to "strafe"
    [SerializeField]
    private Vector3 moveTo;
    [SerializeField]
    private Transform lookAt;
    private GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EntityStats>();
        moveTo = transform.position;
        currentTarget = GameObject.FindWithTag("Player");
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = stats.moveSpeed;
        
    }

    void Update(){
        //TODO: make this a smooth motion based on stats.horizontalLookSpeed
        transform.LookAt(lookAt);
        if(stats.health <= 0){
            Destroy(gameObject);
        }
    }

    // Used by the AI to control where the Enemy is looking and where it's moving
    public void Move(Vector3 target){
        moveTo = target;
        agent.destination = moveTo;
    }

    public void Look(Transform target){
        lookAt = target;
    }

    public GameObject GetCurrentTarget(){
        return currentTarget;
    }
}
