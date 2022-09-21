using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems; 

public class PlayerMovement : MonoBehaviour
{
    public Camera cam; 
    public NavMeshAgent agent;  
    GameController gameController;
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject() && !gameController.scanning)
        {
            int layerMask = 1 << 6;

            // This would cast rays only against colliders in layer 6.
            // But instead we want to collide against everything except layer 6. The ~ operator does this, it inverts a bitmask.
            layerMask = ~layerMask;

            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit,Mathf.Infinity,layerMask) )
            {
                agent.SetDestination(hit.point);

            }
        }
    }
}
