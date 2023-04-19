using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{   
    public float maxRange = 50.0f;
    public int maxAmmo = 20;
    public int reloadTime = 1;
    public int damage = 10;

    [SerializeField]
    private Transform shootPoint;

    private int curAmmo;
    private float timeInterval = 0.0f;

    private Renderer gunRenderer;


    // Start is called before the first frame update
    void Start()
    {
        gunRenderer = GetComponent<Renderer>();
        curAmmo = maxAmmo;
    }

    void FixedUpdate(){
        timeInterval += Time.deltaTime;
    }

    public int GetAmmo(){
        return curAmmo;
    }

    public bool Shoot(){
        if(timeInterval >= 0.5f && curAmmo > 0){
            curAmmo -= 1;
            timeInterval = 0.0f;
            RaycastHit hit;
            StartCoroutine(ShootingAnimationPlaceholder());
            if(Physics.Raycast(shootPoint.position, shootPoint.TransformDirection(Vector3.forward), out hit, maxRange)){
                EntityStats hitStats = hit.transform.gameObject.GetComponent<EntityStats>();
                if(hitStats != null){
                    hitStats.Damage(damage);
                }
                Debug.DrawRay(shootPoint.position, shootPoint.TransformDirection(Vector3.forward) * hit.distance, Color.red, 0.5f);
                // Debug.Log("Hit! " + hit.distance);
                return true;
            } else {
                Debug.DrawRay(shootPoint.position, shootPoint.TransformDirection(Vector3.forward) * 1000.0f, Color.red, 0.5f);
                // Debug.Log("Miss!");
                return false;
            }
        } else if(curAmmo <= 0){
            // We can't shoot until we reload
            return false;
        }
        // We haven't missed, just waiting out the cooldown
        return true;
    }

    public void Reload(){
        StartCoroutine(ReloadingAnimationPlaceholder());
    }

    IEnumerator ReloadingAnimationPlaceholder(){
        gunRenderer.material.SetColor("_Color", Color.green);
        yield return new WaitForSeconds(reloadTime);
        gunRenderer.material.SetColor("_Color", Color.black);
        curAmmo = maxAmmo;
    }

    IEnumerator ShootingAnimationPlaceholder(){
        gunRenderer.material.SetColor("_Color", Color.white);
        yield return new WaitForSeconds(0.1f);
        gunRenderer.material.SetColor("_Color", Color.black);
    }
}
