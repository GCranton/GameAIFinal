using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public EntityStats stats;

    [SerializeField]
    private GameObject playerObject;
    [SerializeField]
    private Gun gunScript;
    [SerializeField]
    private Camera playerCam;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<EntityStats>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle input
        if(Input.GetButton("Fire1")){
            gunScript.Shoot();
        }
        if(Input.GetButton("Reload")){
            gunScript.Reload();
        }

        transform.Translate(Input.GetAxis("Vertical") * stats.moveSpeed * Time.deltaTime, 0, -1 * Input.GetAxis("Horizontal") * stats.moveSpeed * Time.deltaTime);
        transform.Rotate(0, Input.GetAxis("Mouse X") * stats.horizontalLookSpeed, 0);
        playerCam.transform.Rotate(-1 * Input.GetAxis("Mouse Y") * stats.verticalLookSpeed, 0, 0);
    }
}
