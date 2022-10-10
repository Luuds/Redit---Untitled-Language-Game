using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnvironmentHotspot : MonoBehaviour
{
    public int evObjID; 
    public string evObjName;
    public string evObjSlug;
    public List<int> evObjItemAcceptList = new List<int>();
    public Hotspot thisHotspotData;
    private GameController gameController;
    private EnvironmentHotspotDatabaseCreator evObjdatabaseCreator;
    private WordDatabaseCreator wordDatabaseCreator;
    private Renderer _myRenderer;
    bool scanned =false;
    [HideInInspector] public bool isBeingScanned = false;

    // Start is called before the first frame update
    void Start()
    {
        _myRenderer= GetComponent<Renderer>();
        evObjName = this.gameObject.name;
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        evObjdatabaseCreator = gameController.gameObject.GetComponent<EnvironmentHotspotDatabaseCreator>();
        wordDatabaseCreator = gameController.gameObject.GetComponent<WordDatabaseCreator>();
        thisHotspotData = gameController.gameObject.GetComponent<EnvironmentHotspotDatabaseCreator>().FetchHotspotByTitle(evObjName);
        evObjID = thisHotspotData.ID; 
        evObjSlug = thisHotspotData.Slug;
        evObjItemAcceptList = thisHotspotData.itemAcceptList;
        if (gameController.environmentHotspotScanned[evObjID] == 1) 
        {
            scanned = true;
        }
    }
    public void IsBeingScanned() 
    {   if (!scanned)
        {
          
            StartCoroutine(ScanFadeEffect());
            StartCoroutine(ScanPatternEffect());
            Debug.Log("Isbeing scanned");
            isBeingScanned = false;
            gameController.environmentHotspotScanned[evObjID] = 1;
            gameController.wordsFound[wordDatabaseCreator.FetchWordByTitle(evObjName).ID] = 1;
            scanned = true;
        }
    }
    IEnumerator ScanFadeEffect() 
    { 
        while (_myRenderer.material.GetFloat("_HoloStrength") > 0) 
        {
            _myRenderer.material.SetFloat("_HoloStrength", _myRenderer.material.GetFloat("_HoloStrength") - 0.01f);
            yield return new WaitForSeconds(0.1f); 
        }
        _myRenderer.material.SetFloat("_HoloStrength", 0); 
        yield return null;
    
    }
    IEnumerator ScanPatternEffect()
    {
        _myRenderer.material.SetFloat("_ScanEffect", 0); 
        while (_myRenderer.material.GetFloat("_ScanEffect") < 0.84f)
        {
            _myRenderer.material.SetFloat("_ScanEffect", _myRenderer.material.GetFloat("_ScanEffect")+ 0.01f);
            yield return new WaitForSeconds(0.05f);
        }
        _myRenderer.material.SetFloat("_ScanEffect", 0);
        yield return null;

    }

    void ScanTriggered() {
        _myRenderer.material.SetFloat("_Holo", 1);
        if (scanned) { _myRenderer.material.SetFloat("_HoloStrength", 0);  }
       // _myRenderer.material.SetInteger("_Holo", 1);
        Debug.Log("Scanned");
       
    }
    void ScanUnTriggered()
    {
        _myRenderer.material.SetFloat("_Holo", 0);
        Debug.Log("UnScanned");
    }
    // Update is called once per frame
    void Update()
    {

    }


}
