using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnvironmentHotspot : MonoBehaviour
{
    public int evObjID =1; 
    public string evObjName;
    public string evObjSlug;
    public List<int> evObjItemAcceptList = new List<int>();
    public Hotspot thisHotspotData;
    private GameController gameController;
    private EnvironmentHotspotDatabaseCreator evObjdatabaseCreator;
    private Renderer _myRenderer; 

    // Start is called before the first frame update
    void Start()
    {
        _myRenderer= GetComponent<Renderer>();
        evObjName = this.gameObject.name;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        evObjdatabaseCreator = gameController.gameObject.GetComponent<EnvironmentHotspotDatabaseCreator>();
        thisHotspotData = gameController.gameObject.GetComponent<EnvironmentHotspotDatabaseCreator>().FetchHotspotByTitle(evObjName);
        evObjID = thisHotspotData.ID; 
        evObjSlug = thisHotspotData.Slug;
        evObjItemAcceptList = thisHotspotData.itemAcceptList;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScanTriggered() {
        _myRenderer.material.SetFloat("_Holo", 1);
       // _myRenderer.material.SetInteger("_Holo", 1);
        Debug.Log("Scanned");
    }
    void ScanUnTriggered()
    {
        _myRenderer.material.SetFloat("_Holo", 0);
        Debug.Log("UnScanned");
    }
}
