using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerActivation : MonoBehaviour
{
    EnvironmentHotspotDatabaseCreator environmentHotspotDatabase;
    GameObject environment;
    GameController gameController;
    private bool scanning = false; 
    // Start is called before the first frame update
    void Start()
    {
        environment = GameObject.FindGameObjectWithTag("Environment");
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

   public void ScanOnorOff() {
        if (!scanning) 
        {
            environment.BroadcastMessage("ScanTriggered");
            scanning = true; 
        }
        else { environment.BroadcastMessage("ScanUnTriggered");
            scanning = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        gameController.scanning = scanning;
    }
}
