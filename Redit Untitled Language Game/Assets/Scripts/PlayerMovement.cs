using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems; 

public class PlayerMovement : MonoBehaviour
{
    public Camera cam; 
    public NavMeshAgent agent;  
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; 
            if (Physics.Raycast(ray, out hit) )
            {
                agent.SetDestination(hit.point);

            }
        }
    }
}
