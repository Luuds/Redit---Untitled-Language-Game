using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScanSpotTrigger : MonoBehaviour
{   GameController gameController;
    GameObject robot; 
    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        robot = GameObject.FindGameObjectWithTag("Robot");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Robot") && gameController.scanning && transform.GetComponentInParent<EnvironmentHotspot>().isBeingScanned) 
        {
            Debug.Log("Triggered");
            transform.GetComponentInParent<EnvironmentHotspot>().IsBeingScanned(); 
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
