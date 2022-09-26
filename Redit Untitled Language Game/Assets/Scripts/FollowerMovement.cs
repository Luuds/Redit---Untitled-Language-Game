using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class FollowerMovement : MonoBehaviour
{
    public Camera cam;
    public GameObject myTarget;
    NavMeshAgent myAgent;
    public int range;

    GameController gameController;
    //bool rotate = false;
    GameObject tempScanPos;
    int layerMask;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        myAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("DistanceCheck", 0, 0.1f);

        layerMask = 1 << 6;
        layerMask = ~layerMask;
    }
    void DistanceCheck ()
    {
        float dist = Vector3.Distance(this.transform.position, myTarget.transform.position);
        if (dist > range && !gameController.scanning)
        {
            myAgent.destination = myTarget.transform.position;
        }

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && gameController.scanning)
        {
            tempScanPos = null; 
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            if (hit.collider.CompareTag("Scannable"))
            {
                GameObject tempHotspotObj = hit.collider.gameObject;
                tempScanPos = tempHotspotObj.transform.GetChild(0).gameObject;
                myAgent.SetDestination(tempScanPos.transform.position);
                tempHotspotObj.GetComponent<EnvironmentHotspot>().isBeingScanned = true;
                //rotate = true;
            }
            else 
            {
                ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
                {
                    myAgent.SetDestination(hit.point);

                }
            }
        }
    // if (gameController.scanning && tempScanPos != null) { FaceTarget();  }

    }
    void FaceTarget()
    {
        var turnTowardNavSteeringTarget = myAgent.steeringTarget;

        Vector3 direction = (turnTowardNavSteeringTarget - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(0, direction.y, direction.z));
        Quaternion scanPosRot = tempScanPos.transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);

    }
}
