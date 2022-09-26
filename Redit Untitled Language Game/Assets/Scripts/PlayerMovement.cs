using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI; 
using UnityEngine.AI;
using UnityEngine.EventSystems; 

public class PlayerMovement : MonoBehaviour 
{
    public Camera cam; 
    public NavMeshAgent agent;  
    GameController gameController;
    public float holdTime;
   // public UnityEvent onLongClick;
    bool pointerDown;
    float pointerDownTimer;
    int layerMask;
    Ray ray;
    RaycastHit hit;
    GameObject touchRing;
    GameObject tempTouchRing;
    Image fillImage; 
    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 6;

        // This would cast rays only against colliders in layer 6.
        // But instead we want to collide against everything except layer 6. The ~ operator does this, it inverts a bitmask.
        layerMask = ~layerMask;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        agent = GetComponent<NavMeshAgent>();
        touchRing = Resources.Load("Prefabs/TouchRing") as GameObject;
       
    }
  
    // Update is called once per frame
    void Update()
    {    if (Input.GetMouseButtonDown(0)&& !EventSystem.current.IsPointerOverGameObject() && !gameController.inventoryOpen)
        {
            tempTouchRing = Instantiate(touchRing, GameObject.FindGameObjectWithTag("Canvas").transform);
            tempTouchRing.transform.position = Input.mousePosition;
            fillImage = tempTouchRing.GetComponent<Image>();
            pointerDown = true; 
        }
        if (Input.GetMouseButtonUp(0)) 
        {   Reset(); 
            Move();
            
        }
       
        if (pointerDown && !EventSystem.current.IsPointerOverGameObject() && !gameController.scanning)
        {
            
                pointerDownTimer += Time.deltaTime;
                fillImage.fillAmount = (pointerDownTimer -0.1f) / holdTime;
                if ((pointerDownTimer - 0.15f) >= holdTime)
                {
                    Interact();
                    Reset();
                }

            }
        
    }
    private void Reset()
    {
        pointerDown = false;
       
        Destroy(tempTouchRing);
        pointerDownTimer = 0;
    }
    private void Interact()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit,Mathf.Infinity, layerMask);
        if (hit.collider.CompareTag("PickUpItem")) 
        {
        Destroy(hit.collider.gameObject);
        }
            Debug.Log("Interact");
    }
    private void Move()

    {
        if ( !EventSystem.current.IsPointerOverGameObject() && !gameController.scanning && !gameController.inventoryOpen)
        {
            ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                agent.SetDestination(hit.point);

            }
        }

    }
}
